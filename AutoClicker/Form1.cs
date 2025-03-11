using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class AutoClicker : Form
    {
        //WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI 
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        //WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI WinAPI 

        //Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse 
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse Mouse 

        //MOUSE EVENT MOUSE EVENT MOUSE EVENT MOUSE EVENT MOUSE EVENT MOUSE EVENT MOUSE EVENT MOUSE EVENT
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        //MOUSE EVENT MOUSE EVENT MOUSE EVENT MOUSE EVENT MOUSE EVENT MOUSE EVENT MOUSE EVENT MOUSE EVENT

        //HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS 
        private const int HOTKEY_ID_START = 1; // Идентификатор для F6
        private const int HOTKEY_ID_STOP = 2; // Идентификатор для F7
        //HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS HOT KEYS 

        //CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK 
        private System.Windows.Forms.Timer clickTimer; // Таймер для кликов
        private System.Windows.Forms.Timer durationTimer; // Таймер для ограничения времени работы
        private int clickInterval; // Интервал кликов в миллисекундах
        private int duration; // Время работы в секундах
        //CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK CLICK 

        public AutoClicker()
        {
            InitializeComponent();
            clickTimer = new System.Windows.Forms.Timer();
            durationTimer = new System.Windows.Forms.Timer();
            clickTimer.Tick += ClickTimer_Tick!;
            durationTimer.Tick += DurationTimer_Tick!;

            // Подключаем обработчик события KeyDown
            this.KeyDown += Form1_KeyDown!;
            this.KeyPreview = true; // Разрешаем форме перехватывать события клавиш

            //REGISTER HOT KEYS REGISTER HOT KEYS REGISTER HOT KEYS REGISTER HOT KEYS REGISTER HOT KEYS 
            RegisterHotKey(this.Handle, HOTKEY_ID_START, 0, (int)Keys.F6); // F6
            RegisterHotKey(this.Handle, HOTKEY_ID_STOP, 0, (int)Keys.F7); // F7
            //REGISTER HOT KEYS REGISTER HOT KEYS REGISTER HOT KEYS REGISTER HOT KEYS REGISTER HOT KEYS 

            //FORM STYLE FORM STYLE FORM STYLE FORM STYLE FORM STYLE FORM STYLE FORM STYLE FORM STYLE 
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            //FORM STYLE FORM STYLE FORM STYLE FORM STYLE FORM STYLE FORM STYLE FORM STYLE FORM STYLE 
        }

        // Переопределяем метод WndProc для перехвата сообщений
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312; // Сообщение о нажатии горячей клавиши

            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32(); // Получаем идентификатор горячей клавиши

                switch (id)
                {
                    case HOTKEY_ID_START:
                        buttonStart_Click(null!, null!); // Запуск автокликера
                        break;
                    case HOTKEY_ID_STOP:
                        buttonStop_Click(null!, null!); // Остановка автокликера
                        break;
                }
            }

            base.WndProc(ref m);
        }

        //KEY DOWN KEY DOWN KEY DOWN KEY DOWN KEY DOWN KEY DOWN KEY DOWN KEY DOWN KEY DOWN KEY DOWN 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Если нажата F6, запускаем автокликер
            if (e.KeyCode == Keys.F6)
            {
                buttonStart_Click(null!, null!); // Вызываем метод старта
            }

            // Если нажата F7, останавливаем автокликер
            if (e.KeyCode == Keys.F7)
            {
                buttonStop_Click(null!, null!); // Вызываем метод остановки
            }
        }
        //KEY DOWN KEY DOWN KEY DOWN KEY DOWN KEY DOWN KEY DOWN KEY DOWN KEY DOWN KEY DOWN KEY DOWN 

        //START CLICK START CLICK START CLICK START CLICK START CLICK START CLICK START CLICK START CLICK 
        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Получаем интервал кликов из textBoxInterval
            if (!int.TryParse(textBoxInterval.Text, out clickInterval) || clickInterval <= 0)
            {
                MessageBox.Show("Введите интервал в миллисекундах!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получаем время работы из textBoxDuration
            if (!int.TryParse(textBoxDuration.Text, out duration) || duration <= 0)
            {
                MessageBox.Show("Введите время работы в секундах!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //START CLICK START CLICK START CLICK START CLICK START CLICK START CLICK START CLICK START CLICK 



        //TIMER START TIMER START TIMER START TIMER START TIMER START TIMER START TIMER START TIMER START 
            clickTimer.Interval = clickInterval;
            clickTimer.Start();

            durationTimer.Interval = duration * 1000; // Переводим секунды в миллисекунды
            durationTimer.Start();

            // Блокируем кнопку "Старт" и разблокируем "Стоп"
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;

            // Отладочный вывод
            Console.WriteLine("Автокликер запущен!");
        }
        //TIMER START TIMER START TIMER START TIMER START TIMER START TIMER START TIMER START TIMER START 



        //STOP CLICK STOP CLICK STOP CLICK STOP CLICK STOP CLICK STOP CLICK STOP CLICK STOP CLICK STOP CLICK 
        private void buttonStop_Click(object sender, EventArgs e)
        {
            // Останавливаем таймеры
            clickTimer.Stop();
            durationTimer.Stop();

            // Разблокируем кнопку "Старт" и блокируем "Стоп"
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;

            // Отладочный вывод
            Console.WriteLine("Автокликер остановлен!");
        }
        //STOP CLICK STOP CLICK STOP CLICK STOP CLICK STOP CLICK STOP CLICK STOP CLICK STOP CLICK STOP CLICK 

        //CLICK TIMER CLICK TIMER CLICK TIMER CLICK TIMER CLICK TIMER CLICK TIMER CLICK TIMER CLICK TIMER 
        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            // Выполняем клик
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            // Отладочный вывод
            Console.WriteLine("Клик выполнен!");
        }
        //CLICK TIMER CLICK TIMER CLICK TIMER CLICK TIMER CLICK TIMER CLICK TIMER CLICK TIMER CLICK TIMER 

        //DURATION TICK DURATION TICK DURATION TICK DURATION TICK DURATION TICK DURATION TICK DURATION TICK 
        private void DurationTimer_Tick(object sender, EventArgs e)
        {
            // Останавливаем таймеры
            clickTimer.Stop();
            durationTimer.Stop();

            // Разблокируем кнопку "Старт" и блокируем "Стоп"
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;

            // Отладочный вывод
            Console.WriteLine("Автокликер остановлен по истечении времени!");

            MessageBox.Show("Автокликер остановлен по истечении времени.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //DURATION TICK DURATION TICK DURATION TICK DURATION TICK DURATION TICK DURATION TICK DURATION TICK 

        //CANCEL REGISTER CLICK___ CANCEL REGISTER CLICK___ CANCEL REGISTER CLICK___ CANCEL REGISTER CLICK___ 
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            UnregisterHotKey(this.Handle, HOTKEY_ID_START); // Отменяем F6
            UnregisterHotKey(this.Handle, HOTKEY_ID_STOP); // Отменяем F7
            base.OnFormClosed(e);
        }
        //CANCEL REGISTER CLICK___ CANCEL REGISTER CLICK___ CANCEL REGISTER CLICK___ CANCEL REGISTER CLICK___ 

    }
}