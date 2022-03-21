using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Gamma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void    Form1_Load(object sender, EventArgs e)
        {}
        private void    richTextBox1_TextChanged(object sender, EventArgs e) // ключ
        {
            Encode_Key();
        }
        private void    richTextBox2_TextChanged(object sender, EventArgs e) // ключ в бинарке
        {}
        private void    richTextBox3_TextChanged(object sender, EventArgs e) // исходный текст
        {
            Encode_Text();
        }
        private void    richTextBox4_TextChanged(object sender, EventArgs e) // исходный текст в бинарке
        {}
        private void    richTextBox5_TextChanged(object sender, EventArgs e) // полученный текст
        {}
        private void    richTextBox6_TextChanged(object sender, EventArgs e) // полученный текст в бинарке
        {}
        static readonly Random rand = new Random();
        static string   Shuffle(string s)
        {
            var chars = s.ToCharArray();
            for (int i = chars.Length - 1; i > 0; i--)
            {
                int j = rand.Next(i);
                (chars[i], chars[j]) = (chars[j], chars[i]);
            }
            return new string(chars);
        } // перемешивание ключа при автоматической генерации
        string          TwoBits(int index)
        {
            string dest = "";
            int temp = index;
            int counter = 0;
            while (temp != 0)
            {
                temp /= 2;
                counter++;
            }
            string nuls = "";
            while (index > 0)
            {
                dest = ((index % 2 == 0) ? "0" : "1") + dest;
                index /= 2;
            }
            while (6 - counter > 0)
            {
                nuls += '0';
                counter++;
            }
            nuls += dest;
            return (nuls);
        } // перевод символа из десятичного в двоичную
        string          Converter()
        {
            string eng_alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ№@<>";
            string ru_alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦ";
            string first = richTextBox3.Text.ToUpper();
            first = first.Replace(" ", "");
            string second = "";
            int[] index = new int[first.Length];
            if (comboBox1.SelectedItem == "Русский")
            {
                for (int i = 0; i < first.Length; i++)
                {
                    for (int j = 0; j < ru_alphabet.Length; j++)
                    {
                        if (first[i] == ru_alphabet[j])
                        {
                            index[i] = j;
                            break;
                        }
                    }
                }
            }
            if (comboBox1.SelectedItem == "Английский")
            {
                for (int i = 0; i < first.Length; i++)
                {
                    for (int j = 0; j < eng_alphabet.Length; j++)
                    {
                        if (first[i] == eng_alphabet[j])
                        {
                            index[i] = j;
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < index.Length; i++)
                second += TwoBits(index[i]);
            return (second);
        } // конвертер текста из заданной системы в двоичную
        string          Converter_For_Key()
        {
            string eng_alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ№@<>";
            string ru_alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦ";
            string first = richTextBox1.Text.ToUpper();
            string second = "";
            int[] index = new int[first.Length];
            if (comboBox1.SelectedItem == "Русский")
            {
                for (int i = 0; i < first.Length; i++)
                {
                    for (int j = 0; j < ru_alphabet.Length; j++)
                    {
                        if (first[i] == ru_alphabet[j])
                        {
                            index[i] = j;
                            break;
                        }
                    }
                }
            }
            if (comboBox1.SelectedItem == "Английский")
            {
                for (int i = 0; i < first.Length; i++)
                {
                    for (int j = 0; j < eng_alphabet.Length; j++)
                    {
                        if (first[i] == eng_alphabet[j])
                        {
                            index[i] = j;
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < index.Length; i++)
                second += TwoBits(index[i]);
            return (second);
        } // конвертер ключа из заданной системы в двоичную
        int             Encode_Text() // Перевод исходного в бинарку
        {
            richTextBox4.Text = "";
            string first = richTextBox3.Text.ToUpper();
            if (comboBox1.SelectedItem == "Русский")
            {
                string ru_Alpha = " АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦ";
                for (int i = 0; i < first.Length; i++)
                {
                    int checker = 0;
                    for (int j = 0; j < ru_Alpha.Length; j++)
                    {
                        if (first[i] == ru_Alpha[j])
                            checker = 1;
                    }
                    if (checker == 0)
                    {
                        richTextBox3.Text = "";
                        richTextBox4.Text = "";
                        MessageBox.Show("Вы ввели некорректные символы в исходном тексте");
                        return 0;
                    }
                }
            } // проверка исходного текста на символы
            if (comboBox1.SelectedItem == "Английский")
            {
                string eng_Alpha = " ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ№@<>";
                for (int i = 0; i < first.Length; i++) // проверка исходного текста
                {
                    int checker = 0;
                    for (int j = 0; j < eng_Alpha.Length; j++)
                    {
                        if (first[i] == eng_Alpha[j])
                            checker = 1;
                    }
                    if (checker == 0)
                    {
                        richTextBox3.Text = "";
                        richTextBox4.Text = "";
                        MessageBox.Show("Вы ввели некорректные символы в исходном тексте");
                        return 0;
                    }
                }
            } // проверка исходного текста на символы
            if (comboBox1.SelectedItem != "Русский" && comboBox1.SelectedItem != "Английский") // проверка выбранного языка
            {
                richTextBox3.Text = "";
                MessageBox.Show("Выберите язык");
                return 0;
            }
            richTextBox4.Text = Converter();
            return 1;
        }
        int             Encode_Key() // Перевод ключа в бинарку
        {
            richTextBox2.Text = "";
            string first = richTextBox1.Text.ToUpper();
            if (comboBox1.SelectedItem == "Русский")
            {
                string ru_Alpha = " АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦ";
                for (int i = 0; i < first.Length; i++)
                {
                    int checker = 0;
                    for (int j = 0; j < ru_Alpha.Length; j++)
                    {
                        if (first[i] == ru_Alpha[j])
                            checker = 1;
                    }
                    if (checker == 0)
                    {
                        richTextBox1.Text = "";
                        richTextBox2.Text = "";
                        MessageBox.Show("Вы ввели некорректные символы в ключе");
                        return 0;
                    }
                }
            } // проверка ключа на символы
            if (comboBox1.SelectedItem == "Английский")
            {
                string eng_Alpha = " ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ№@<>";
                for (int i = 0; i < first.Length; i++) // проверка исходного текста
                {
                    int checker = 0;
                    for (int j = 0; j < eng_Alpha.Length; j++)
                    {
                        if (first[i] == eng_Alpha[j])
                            checker = 1;
                    }
                    if (checker == 0)
                    {
                        richTextBox1.Text = "";
                        richTextBox2.Text = "";
                        MessageBox.Show("Вы ввели некорректные символы в ключе");
                        return 0;
                    }
                }
            } // проверка ключа на символы
            if (comboBox1.SelectedItem != "Русский" && comboBox1.SelectedItem != "Английский") // проверка выбранного языка
            {
                richTextBox1.Text = "";
                richTextBox5.Text = "";
                MessageBox.Show("Выберите язык");
                return 0;
            }
            if (comboBox2.SelectedItem != "Ключ" && comboBox2.SelectedItem != "Генерация") // проверка выбранного языка
            {
                richTextBox1.Text = "";
                richTextBox5.Text = "";
                MessageBox.Show("Выберите каким способом задаём ключ");
                return 0;
            }
            richTextBox2.Text = Converter_For_Key();
            return 1;
        }           
        int[]           Encode_Key_Auto() // Перевод ключа в бинарку автоматически
        {
            Random rand = new Random();
            richTextBox2.Text = "";
            string first = richTextBox3.Text.ToUpper();
            first = first.Replace(" ", "");
            int length = first.Length;
            int[] arr = new int[length];
            int[] RANDOM = new int[10];
            RANDOM[0] = 7; RANDOM[1] = 11; RANDOM[2] = 13; RANDOM[3] = 14; RANDOM[4] = 19; RANDOM[5] = 21;
            RANDOM[6] = 22; RANDOM[7] = 25; RANDOM[8] = 26; RANDOM[9] = 28;
            for (int i = 0; i < length; i++)
            {
                int r = RANDOM[rand.Next(0, 9)];
                arr[i] = r;
                richTextBox2.Text += TwoBits(r);
            }
            return (arr);
        }
        void            Decrypt() // Функция расшифровки
        {
            richTextBox7.Text = "";
            string first = richTextBox2.Text;
            string second = richTextBox6.Text;
            string dest = richTextBox8.Text;
            for (int i = 0; i < second.Length; i++)
            {
                dest += (Convert.ToInt32(first[i]) ^ Convert.ToInt32(second[i])).ToString();
            }
            richTextBox8.Text = dest;
            return;
        }
        void            Encrypt()
        {
            richTextBox7.Text = "";
            richTextBox8.Text = "";
            if (richTextBox3.Text == "") // проверка исхоdного текста на то что он пуст
            {
                MessageBox.Show("Вы не ввели исходный текст");
                richTextBox4.Text = "";
                return ;
            }
            if (richTextBox2.Text == "")
            {
                MessageBox.Show("Вы не ввели ключ");
                richTextBox2.Text = "";
                return;
            }
            string first = richTextBox4.Text;
            string second = richTextBox2.Text;
            string dest = richTextBox6.Text;
            for (int i = 0; i < first.Length; i++)
            {
                dest += (Convert.ToInt32(first[i]) ^ Convert.ToInt32(second[i])).ToString();
            }
            richTextBox6.Text = dest;
        } // функция зашифровки
        void            Converter_From_Dest()
        {
            string eng_alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ№@<>";
            string ru_alphabet =  "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦ";
            string first = richTextBox3.Text.ToUpper();
            first = first.Replace(" ", "");
            string second = richTextBox1.Text.ToUpper();
            int[] index1 = new int[first.Length];
            int[] index2 = new int[second.Length];
            string dest = "";
            if (comboBox1.SelectedItem == "Русский")
            {
                for (int i = 0; i < first.Length; i++)
                {
                    for (int j = 0; j < ru_alphabet.Length; j++)
                    {
                        if (first[i] == ru_alphabet[j])
                        {
                            index1[i] = j;
                            break;
                        }
                    }
                }
                for (int i = 0; i < second.Length; i++)
                {
                    for (int j = 0; j < ru_alphabet.Length; j++)
                    {
                        if (second[i] == ru_alphabet[j])
                        {
                            index2[i] = j;
                            break;
                        }
                    }
                }
                for (int i = 0; i < index1.Length; i++)
                {
                    dest += ru_alphabet[index1[i] ^ index2[i]];
                }
            }
            if (comboBox1.SelectedItem == "Английский")
            {
                for (int i = 0; i < first.Length; i++)
                {
                    for (int j = 0; j < eng_alphabet.Length; j++)
                    {
                        if (first[i] == eng_alphabet[j])
                        {
                            index1[i] = j;
                            break;
                        }
                    }
                }
                for (int i = 0; i < second.Length; i++)
                {
                    for (int j = 0; j < eng_alphabet.Length; j++)
                    {
                        if (second[i] == eng_alphabet[j])
                        {
                            index2[i] = j;
                            break;
                        }
                    }
                }
                for (int i = 0; i < index1.Length; i++)
                {
                    dest += eng_alphabet[index1[i] ^ index2[i]];
                }
            }
            richTextBox5.Text = dest.ToLower();
        } // функция перевода при ручном вводе из бинарного кода  в текст моего алфавита
        void            Convert_Dec_From_Two_To_Alpha() // функция перевода при автоматическом вводе в текст ключа моего алфаваита
        {
            string eng_alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ№@<>";
            string ru_alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦ";
            string first = richTextBox5.Text.ToUpper();
            string second = richTextBox1.Text.ToUpper();
            string dest = "";
            int []index1 = new int[first.Length];
            int []index2 = new int[second.Length];
            if (comboBox1.SelectedItem == "Русский")
            {
                for (int i = 0; i < first.Length; i++)
                {
                    for (int j = 0; j < ru_alphabet.Length; j++)
                    {
                        if (first[i] == ru_alphabet[j])
                        {
                            index1[i] = j;
                            break;
                        }
                    }
                }
                for (int i = 0; i < second.Length; i++)
                {
                    for (int j = 0; j < ru_alphabet.Length; j++)
                    {
                        if (second[i] == ru_alphabet[j])
                        {
                            index2[i] = j;
                            break;
                        }
                    }
                }
                for (int i = 0; i < first.Length; i++)
                {
                    dest += ru_alphabet[index1[i] ^ index2[i]];
                }
            }
            if (comboBox1.SelectedItem == "Английский")
            {
                for (int i = 0; i < first.Length; i++)
                {
                    for (int j = 0; j < eng_alphabet.Length; j++)
                    {
                        if (first[i] == eng_alphabet[j])
                        {
                            index1[i] = j;
                            break;
                        }
                    }
                }
                for (int i = 0; i < second.Length; i++)
                {
                    for (int j = 0; j < eng_alphabet.Length; j++)
                    {
                        if (second[i] == eng_alphabet[j])
                        {
                            index2[i] = j;
                            break;
                        }
                    }
                }
                for (int i = 0; i < first.Length; i++)
                {
                    dest += eng_alphabet[index1[i] ^ index2[i]];
                }
            }
            richTextBox7.Text = dest.ToLower();
            return;
        }
        void            Convert_Key_From_Two_To_Alpha() // функция перевода при автоматическом вводе в текст ключа моего алфаваита
        {
            int[] arr = Encode_Key_Auto();
            string eng_alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ№@<>";
            string ru_alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦ";
            string dest = "";
            if (comboBox1.SelectedItem == "Русский")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < ru_alphabet.Length; j++)
                    {
                        if (arr[i] == j)
                        {
                            dest += ru_alphabet[j];
                            break;
                        }
                    }
                }
            }
            if (comboBox1.SelectedItem == "Английский")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < eng_alphabet.Length; j++)
                    {
                        if (arr[i] == j)
                        {
                            dest += eng_alphabet[j];
                            break;
                        }
                    }
                }
            }
            richTextBox1.Text = dest.ToLower();
        }
        private void    button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != "Русский" && comboBox1.SelectedItem != "Английский") // выбор языка
            { 
                MessageBox.Show("Выберите язык");
                return;
            }
            if (comboBox1.SelectedItem == "Русский" && Encode_Text() == 0) //проверка входного текста
                return;
            if (comboBox1.SelectedItem == "Английский" && Encode_Text() == 0)//проверка входного текста
                return;
            if (comboBox2.SelectedItem == "Ключ" && Encode_Key() == 0) //проверка ключа
                return;
            if (comboBox2.SelectedItem == "Ключ" && richTextBox4.Text.Length > richTextBox2.Text.Length)// проверка ключа на длину
            {
                MessageBox.Show("Вы ввели слишком маленький ключ");
                richTextBox5.Text = "";
                richTextBox6.Text = "";
                return;
            }
            if (comboBox2.SelectedItem == "Генерация")
            {
                Encode_Key_Auto();
                Convert_Key_From_Two_To_Alpha();
            }
            if (comboBox2.SelectedItem != "Генерация" && comboBox2.SelectedItem != "Ключ")
            {
                MessageBox.Show("Как мы задаем ключ ?");
                return;
            }
            richTextBox6.Text = "";
            Encrypt();
            Converter_From_Dest();
        }
        private void    button2_Click(object sender, EventArgs e)
        {
            richTextBox8.Text = "";
            if (richTextBox6.Text == "" || richTextBox2.Text == "")
            {
                MessageBox.Show("Расшифровка невозможна");
                return;
            }
            else
            {
                Decrypt();
                Convert_Dec_From_Two_To_Alpha();
                return;
            }
        }
    }
}
