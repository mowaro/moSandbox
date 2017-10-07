﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Binding {
    public partial class MainWindow : Window {
        Person person;

        public MainWindow() {
            InitializeComponent();
            person = new Person() { Age = 18 };
            ageLabel.DataContext = person;
        }

        //ボタンクリックのたびに年をとる魔法のイベント
        private void Button_Click(object sender, RoutedEventArgs e) {
            person.Age++;
        }
    }

    class Person {
        int age;
        public string Name { get; set; }
        public int Age {
            get { return age; }
            set { age = value >= 0 ? value : age; }
        }
    }
}