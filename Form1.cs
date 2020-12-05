using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
//voice english
using System.Speech.Synthesis;

//voice vietnamese
using System.Net.Http;

using Google.Cloud.TextToSpeech.V1;
using Google.Apis.Auth.OAuth2;
using Google.Protobuf;

using System.Net;




namespace Docso
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string cur_path = Path.Combine(Directory.GetCurrentDirectory(), "key.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", cur_path, EnvironmentVariableTarget.Process);
            InitializeComponent();
        }

        string[] mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');

        private string DocHangChuc(double so, bool daydu)
        {
            string chuoi = "";
            Int64 chuc = Convert.ToInt64(Math.Floor((double)(so / 10)));
            Int64 donvi = (Int64)so % 10;
            if (chuc > 1)
            {
                chuoi = " " + mNumText[chuc] + " mươi";
                if (donvi == 1)
                {
                    chuoi += " mốt";
                }
            }
            else if (chuc == 1)
            {
                chuoi = " mười";
                if (donvi == 1)
                {
                    chuoi += " một";
                }
            }
            else if (daydu && donvi > 0)
            {
                chuoi = " lẻ";
            }
            if (donvi == 5 && chuc >= 1)
            {
                chuoi += " lăm";
            }
            else if (donvi > 1 || (donvi == 1 && chuc == 0))
            {
                chuoi += " " + mNumText[donvi];
            }
            return chuoi;
        }
        private string DocHangTram(double so, bool daydu)
        {
            string chuoi = "";
            Int64 tram = Convert.ToInt64(Math.Floor((double)so / 100));
            so = so % 100;
            if (daydu || tram > 0)
            {
                chuoi = " " + mNumText[tram] + " trăm";
                chuoi += DocHangChuc(so, true);
            }
            else
            {
                chuoi = DocHangChuc(so, false);
            }
            return chuoi;
        }
        private string DocHangTrieu(double so, bool daydu)
        {
            string chuoi = "";
            Int64 trieu = Convert.ToInt64(Math.Floor((double)so / 1000000));
            so = so % 1000000;
            if (trieu > 0)
            {
                chuoi = DocHangTram(trieu, daydu) + " triệu";
                daydu = true;
            }
            //Lấy số hàng nghìn
            Int64 nghin = Convert.ToInt64(Math.Floor((double)so / 1000));
            //Lấy phần dư sau số hàng nghin 
            so = so % 1000;
            if (nghin > 0)
            {
                chuoi += DocHangTram(nghin, daydu) + " nghìn";
                daydu = true;
            }
            if (so > 0)
            {
                chuoi += DocHangTram(so, daydu);
            }
            return chuoi;
        }

        public string ChuyenSoSangChuoi(double so)
        {
            if (so == 0)
                return mNumText[0];
            string chuoi = "", hauto = "";
            Int64 ty;
            do
            {
                ty = Convert.ToInt64(Math.Floor((double)so / 1000000000));
                so = so % 1000000000;
                if (ty > 0)
                {
                    chuoi = DocHangTrieu(so, true) + hauto + chuoi;
                }
                else
                {
                    chuoi = DocHangTrieu(so, false) + hauto + chuoi;
                }
                hauto = " tỷ";
            } while (ty > 0);
            
            if (chuoi[0] == ' ')
            {
                chuoi = chuoi.Substring(1);
            }

            string res = char.ToUpper(chuoi[0]) + chuoi.Substring(1);

            return res;
        }
    
        public static string NumberToWords(long number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000000000) > 0)
            {
                words += NumberToWords(number / 1000000000000) + " trillion ";
                number %= 1000000000000;
            }

            if ((number / 1000000000) > 0)
            {
                words += NumberToWords(number / 1000000000) + " billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "one", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }

            string res = words;

            return res;
        }

        string xuly(string x)
        {
            
            var str = x;
            var charsToRemove = new string[] {","};
            foreach (var c in charsToRemove)
            {
                str = str.Replace(c, string.Empty);
            }

            return str;

        }

        private void viBtn_CheckedChanged(object sender, EventArgs e)
        {
            input_TextChanged(sender, e);
        }

        private void enBtn_CheckedChanged(object sender, EventArgs e)
        {
            input_TextChanged(sender, e);
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            string inpTemp = input.Text;

            string inpStr = xuly(inpTemp);

            long inp;
            bool success = Int64.TryParse(inpStr, out inp);

            if (input.Text != "")
            {
                if (success)
                {
                    input.Text = inp.ToString("#,##0");
                    input.Select(input.Text.Length, 0);
                    if (viBtn.Checked == true)
                    {
                        if (inp > 1000000000)
                            output.Text = "Vui lòng nhập số bé hơn 1 tỷ";
                        else output.Text = ChuyenSoSangChuoi(inp);
                    }
                    else
                    {
                        string outtttt = NumberToWords(inp);
                        string ress = char.ToUpper(outtttt[0]) + outtttt.Substring(1);

                        output.Text = ress;
                    }
                }
                else
                {

                    if (inpStr.Length > 18)
                        output.Text = "Quá giới hạn - Out of range";
                    else 
                        output.Text = "Vui lòng không nhập chữ";

                }
            }
            else
            {
                output.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inpTemp = input.Text;

            string inpStr = xuly(inpTemp);

            long inp;
            bool success = Int64.TryParse(inpStr, out inp);


            if (viBtn.Checked == true)
            {
                String payload = ChuyenSoSangChuoi(inp);


                TextToSpeechClient client = TextToSpeechClient.Create();

                SynthesizeSpeechResponse response = client.SynthesizeSpeech(
                    new SynthesisInput()
                    {
                        Text = payload
                    },
                    new VoiceSelectionParams()
                    {
                        LanguageCode = "vi-VN",
                        Name = "vi-VN-Standard-A"
                    },
                    new AudioConfig()
                    {
                        AudioEncoding = AudioEncoding.Linear16
                    }
                );

                string speechFile = Path.Combine(Directory.GetCurrentDirectory(), "sample.wav");

                File.WriteAllBytes(speechFile, response.AudioContent.ToByteArray());

                
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(speechFile);
                player.Play();

            }
            else
            {
                var synthesizer = new SpeechSynthesizer();
                synthesizer.SetOutputToDefaultAudioDevice();
                synthesizer.Speak(NumberToWords(inp));
            }
        }
    }
}
