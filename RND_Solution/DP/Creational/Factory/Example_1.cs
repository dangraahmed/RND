using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Creational.Factory
{
    public interface ITextProcessor
    {
        string ReadText();
        void SaveText(string processedText);
    }

    public interface ITextProcessorFactory
    {
        ITextProcessor CreateProcessor();
    }

    public class FileProcessorFactory : ITextProcessorFactory
    {
        public ITextProcessor CreateProcessor()
        {
            return new FileProcessor();
        }
    }

    public class FTPSiteProcessorFactory : ITextProcessorFactory
    {
        public ITextProcessor CreateProcessor()
        {
            return new FTPSiteProcessor();
        }
    }

    public class AzureProcessorFactory : ITextProcessorFactory
    {
        public ITextProcessor CreateProcessor()
        {
            return new AzureProcessor();
        }
    }

    public class FileProcessor : ITextProcessor
    {
        public string ReadText()
        {
            Console.WriteLine("FileProcessor.ReadText");
            return null;
        }

        public void SaveText(string processedText)
        {
            Console.WriteLine("FileProcessor.SaveText");
        }
    }

    public class FTPSiteProcessor : ITextProcessor
    {
        public string ReadText()
        {
            Console.WriteLine("FTPSiteProcessor.ReadText");
            return null;
        }

        public void SaveText(string processedText)
        {
            Console.WriteLine("FTPSiteProcessor.SaveText");
        }
    }

    public class AzureProcessor : ITextProcessor
    {
        public string ReadText()
        {
            Console.WriteLine("AzureProcessor.ReadText");
            return null;
        }

        public void SaveText(string processedText)
        {
            Console.WriteLine("AzureProcessor.SaveText");
        }
    }

    

    public class Example_1
    {
        public static void Main1(string[] args)
        {
        
        }
    }
}
