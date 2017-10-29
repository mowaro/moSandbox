using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoKakebo.Model {
    /// <summary>月</summary>
    class Month {
        /// <summary>年</summary>
        public int year { get; private set; }
        /// <summary>月</summary>
        public int month { get; private set; }

        /// <summary>
        /// Monthオブジェクトのインスタンスを作成する
        /// </summary>
        public Month() {
            DateTime temp = new DateTime();
            year = temp.Year;
            month = temp.Month;
        }

        /// <summary>
        /// 指定された日付のMonthオブジェクトを作成する
        /// </summary>
        /// <param name="date">指定日</param>
        public Month(DateTime date) {
            this.year = date.Year;
            this.month = date.Month;
        }

        /// <summary>
        /// 月の初日を取得する
        /// </summary>
        /// <returns>月の初日</returns>
        public DateTime getFirstDay() {
            return new DateTime(year, month, 1);
        }

        /// <summary>
        /// 月の末日を取得する
        /// </summary>
        /// <returns>月の末日</returns>
        public DateTime getLastDay() {
            return getFirstDay().AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// このインスタンスの値に、指定された月数を加算する
        /// </summary>
        /// <param name="months">月数。months パラメーターは、正または負のどちらの場合もあります。</param>
        public void add(int months) {
            DateTime temp = new DateTime(this.year, this.month, 1).AddMonths(months);
            this.year = temp.Year;
            this.month = temp.Month;
        }
    }
}
