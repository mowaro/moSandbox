using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoKakebo {
    static class Program {
        /// <Summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </Summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NewBusiness());
        }
    }
}
