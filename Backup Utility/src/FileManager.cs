﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace Backup_Utility
{
    static class FileManager
    {
        private static List<ManualResetEvent> MT_Events = new List<ManualResetEvent>();

        #region Public Attributes:
        public static List<string> FilesToSave { get { return PresetManager.CurrentPreset.FilesToSave; } }
        public static List<string> FoldersToSave { get { return PresetManager.CurrentPreset.FoldersToSave; } }
        public static uint BackupNumber { get { return PresetManager.CurrentPreset.BackupNumber; } set { PresetManager.CurrentPreset.BackupNumber = value; } }
        public static bool isThereItemsToSave { get { return FilesToSave.Count > 0 || FoldersToSave.Count > 0; } }
        #endregion

        #region Methods:
        public static void AddFile(string filePath)
        {
            FilesToSave.Add(filePath);
        }

        public static void AddFolder(string folderPath)
        {
            FoldersToSave.Add(folderPath);
        }

        public static void RemoveFromLists(string item)
        {
            var list = FilesToSave.Contains(item) ? FilesToSave : FoldersToSave;
            int index = list.IndexOf(item);
            if (index == -1)
                return;
            list.RemoveAt(index);
        }

        public static void Clear()
        {
            FilesToSave.Clear();
            FoldersToSave.Clear();
        }

        public static bool Backup()
        {
            if (PresetManager.ConfigAndPresets.Multithreaded)
                return BackupMT();
            else
                return BackupST();
        }

        private static bool BackupMT()//todo MT Backup
        {
            try
            {
                MT_Events = new List<ManualResetEvent>();
                DirectoryInfo presetDir = CreateNewFolder(PresetManager.ConfigAndPresets.BackupFolderPath + @"\" + PresetManager.CurrentPreset.PresetName);
                if (presetDir is null)
                    return false;
                DirectoryInfo backupDir = CreateNewFolder(presetDir.FullName + @"\" + "Backup " + PresetManager.CurrentPreset.BackupNumber++.ToString());
                if (backupDir is null)
                    return false;
                foreach (string file in FilesToSave)
                {
                    if (!File.Exists(file))
                    {
                        ErrorLogger.ShowErrorText($"File '{file}' doesn't exist or was deleted, skipping file");
                        continue;
                    }
                    FileInfo fileInfo = new FileInfo(file);
                    MT_Events.Add(new ManualResetEvent(false));
                    int index = MT_Events.Count - 1;
                    ThreadPool.QueueUserWorkItem(state => { File.Copy(fileInfo.FullName, backupDir.FullName + @"\" + fileInfo.Name); MT_Events[(int)state].Set(); }, index);
                }
                foreach (string folder in FoldersToSave)
                {
                    if (!Directory.Exists(folder))
                    {
                        ErrorLogger.ShowErrorText($"Folder '{folder}' doesn't exist or was deleted, skipping folder");
                        continue;
                    }
                    BackupAllInDirMT(new DirectoryInfo(folder), backupDir);
                }
                WaitHandle.WaitAll(MT_Events.ToArray());
                return true;
            }
            catch (Exception exception)
            {
                ErrorLogger.ShowErrorTextWithExceptionMessage("An error occurred while backing up files.", exception, true);
                return false;
            }
        }

        private static void BackupAllInDirMT(DirectoryInfo folderToCopy, DirectoryInfo destDir)
        {
            DirectoryInfo backupDir = CreateNewFolder(destDir.FullName + @"\" + folderToCopy.Name);
            if (backupDir is null)
                return;
            FileInfo[] filesToSave = folderToCopy.GetFiles();
            DirectoryInfo[] foldersToSave = folderToCopy.GetDirectories();
            foreach (FileInfo file in filesToSave)
            {
                MT_Events.Add(new ManualResetEvent(false));
                int index = MT_Events.Count - 1;
                ThreadPool.QueueUserWorkItem(state => { file.CopyTo(Path.Combine(backupDir.FullName, file.Name)); MT_Events[(int)state].Set(); }, index);
            }
            foreach (DirectoryInfo subDirs in foldersToSave)
                BackupAllInDirMT(subDirs, backupDir);
        }

        private static bool BackupST()
        {
            try
            {
                DirectoryInfo presetDir = CreateNewFolder(PresetManager.ConfigAndPresets.BackupFolderPath + @"\" + PresetManager.CurrentPreset.PresetName);
                if (presetDir is null)
                    return false;
                DirectoryInfo backupDir = CreateNewFolder(presetDir.FullName + @"\" + "Backup " + PresetManager.CurrentPreset.BackupNumber++.ToString());
                if (backupDir is null)
                    return false;
                foreach (string file in FilesToSave)
                {
                    if (!File.Exists(file))
                    {
                        ErrorLogger.ShowErrorText($"File '{file}' doesn't exist or was deleted, skipping file");
                        continue;
                    }
                    FileInfo fileInfo = new FileInfo(file);
                    File.Copy(fileInfo.FullName, backupDir.FullName + @"\" + fileInfo.Name);
                }
                foreach (string folder in FoldersToSave)
                {
                    if (!Directory.Exists(folder))
                    {
                        ErrorLogger.ShowErrorText($"Folder '{folder}' doesn't exist or was deleted, skipping folder");
                        continue;
                    }
                    BackupAllInDirST(new DirectoryInfo(folder), backupDir);
                }
                return true;
            }
            catch (Exception exception)
            {
                ErrorLogger.ShowErrorTextWithExceptionMessage("An error occurred while backing up files.", exception, true);
                return false;
            }
        }

        private static void BackupAllInDirST(DirectoryInfo folderToCopy, DirectoryInfo destDir)
        {
            DirectoryInfo backupDir = CreateNewFolder(destDir.FullName + @"\" + folderToCopy.Name);
            if (backupDir is null)
                return;
            FileInfo[] filesToSave = folderToCopy.GetFiles();
            DirectoryInfo[] foldersToSave = folderToCopy.GetDirectories();
            foreach (FileInfo file in filesToSave)
                file.CopyTo(Path.Combine(backupDir.FullName, file.Name));
            foreach (DirectoryInfo subDirs in foldersToSave)
                BackupAllInDirST(subDirs, backupDir);
        }

        private static DirectoryInfo CreateNewFolder(string path)
        {
            DirectoryInfo dir = Directory.CreateDirectory(path);
            return (dir is null || dir.FullName is null) ? null : dir;
        }
        #endregion
    }
}
