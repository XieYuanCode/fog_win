namespace GitHelper
{
    public class GlobalConfigHelper
    {
        public static string GetGlobalConfig(string key)
        {
            string command = "git config --global --get " + key;
            string processOut = execSync(command);
            string config = processOut.Split("\r\n").Last().Trim();
            Console.WriteLine(config);

            return config;
        }

        public static void SetGlobalConfig(string key, string value)
        {
            string command = "git config --global " + key + " " + value;
            execSync(command);
        }

        private static string execSync(string command)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();


            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.StartInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine(command + "&exit");
            p.StandardInput.AutoFlush = true;

            string output = p.StandardOutput.ReadToEnd();

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();

            return output;
        }
    }
}