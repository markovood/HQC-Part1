﻿using System;

namespace CohesionAndCoupling
{
    public static class FileUtils
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new InvalidOperationException("No file extension found!");
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string fileNameWithoutExtension = fileName.Substring(0, indexOfLastDot);
            return fileNameWithoutExtension;
        }

    }
}
