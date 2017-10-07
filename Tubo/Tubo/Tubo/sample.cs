using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubo {
    // enum : Genderの定義
    public enum Gender { Unknown, Male, Female };

    // Genderへの拡張メソッドの定義
    static class GenderExt {
        public static string DisplayName(this Gender gender) {
            string[] names = { "不明", "男性", "女性" };
            return names[(int)gender];
        }
    }

    // モデルクラスの定義
    class Person {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Person(string name, Gender gender) {
            Name = name;
            Gender = gender;
        }
    }

    // ビューモデルの定義
    class ViewModel : ViewModelBase {
        private Person Person { get; set; }
        public string Name {
            get { return Person.Name; }
        }
        public Gender Gender {
            get { return Person.Gender; }
        }
        public ViewModel() {
            Person = new Person("山田太郎", Tubo.Gender.Male);
        }
    }
}

