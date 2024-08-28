using System.Text;

namespace ToolClassLibrary.SystemTools;

public class BatchTools
{
    BatchTools()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }
    /// <summary>
    ///  指定文件夹下所有文件中指定内容替换。
    /// </summary>
    /// <param name="folderPath">文件路径。</param>
    /// <param name="oldText">要替换的内容。</param>
    /// <param name="newText">新内容。</param>
    /// <param name="encoding">文件编码格式。</param>
    public static void FolderReplace(string folderPath, string oldText, string newText, Encoding encoding)
    {
        // 获取文件夹下所有文件并遍历
        string[] files = Directory.GetFiles(folderPath);
        foreach (string file in files)
        {
            string content;
            using (StreamReader reader = new StreamReader(file, encoding))
            {
                content = reader.ReadToEnd();
            }
            content = content.Replace(oldText, newText);
            using (StreamWriter writer = new StreamWriter(file, false, encoding))
            {
                writer.Write(content);
            }
        }
    }

    /// <summary>
    ///  保存文件到start到end行。
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="start">开始行</param>
    /// <param name="end">结束行</param>
    public static void EditFileStartEnd(string filePath, int start, int end)
    {
        // 读取文件内容
        List<string> lines = new List<string>(File.ReadAllLines(filePath));

        // 检查行号是否有效
        if (start > 0 && end <= lines.Count)
        {
            // 从指定行开始保留内容
            var newLines = lines.GetRange(start - 1, end - 1);

            // 将修改后的内容写回到文件
            File.WriteAllLines(filePath, newLines);
        }
        else
        {
            Console.WriteLine("指定的行号无效。");
        }

        return;
    }

    /// <summary>
    ///  文件格式转换。
    /// </summary>
    /// <param name="filePath">文件编码格式</param>
    /// <param name="source">源格式</param>
    /// <param name="to">目标格式</param>
    /// Encoding sourceEncoding = Encoding.UTF8; // 原始文件编码 UTF8
    /// Encoding targetEncoding = Encoding.GetEncoding("shift_jis"); // 目标文件编码
    public static void FileEncodingChange(string filePath, Encoding source, Encoding to)
    {
        try
        {
            // 读取原始文件内容
            string content;
            using (StreamReader reader = new StreamReader(filePath, source))
            {
                content = reader.ReadToEnd();
            }

            // 写入到目标文件中
            using (StreamWriter writer = new StreamWriter(filePath, false, to))
            {
                writer.Write(content);
            }

            Console.WriteLine("文件转换成功！");
        }
        catch (Exception ex)
        {
            Console.WriteLine("发生错误: " + ex.Message);
        }
        return;
    } 
}
