using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization;
using dynamixel_sdk;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Diagnostics.Eventing.Reader;


namespace Motor_test_1
{


    public partial class Form1 : Form
    {
        // Control table address
        public const int ADDR_PRO_TORQUE_ENABLE = 64;
        public const int ADDR_PRO_GOAL_POSITION = 116;
        public const int ADDR_PRO_PRESENT_POSITION = 132;
        public const int ADDR_PRO_GOAL_CURRENT = 102;
        public const int ADDR_PRO_PRRESENT_CURRENT = 126;
        public const int ADDR_PRO_LIMIT_PWM = 36;
        public const int ADDR_PRO_PRRESENT_VELOCITY = 128;
        public const int ADDR_PRO_DRIVING_MODE = 10;
        public const int ADDR_PRO_PRESENT_PWM = 124;
        public const int ADDR_PRO_GOAL_PWM = 100;
        public const int ADDR_PRO_GOAL_VELOCITY = 104;
        public const int ADDR_PRO_LIMIT_VELOCITY = 44;




        // Protocol version
        public const int PROTOCOL_VERSION = 2;                 // See which protocol version is used in the Dynamixel

        // Default setting
        public const int DXL_ID = 1;                           // Dynamixel ID: 1
        public int BAUDRATE = 115200;                    //
        public string DEVICENAME = "COM3";              // Check which port is being used on your controller
                                                        // ex) Windows: "COM1"   Linux: "/dev/ttyUSB0" Mac: "/dev/tty.usbserial-*"

        public const int TORQUE_ENABLE = 1;                    // Value for enabling the torque
        public const int TORQUE_DISABLE = 0;                   // Value for disabling the torque
        public const int DXL_MOVING_STATUS_THRESHOLD = 20;                  // Dynamixel moving status threshold

        public const byte ESC_ASCII_VALUE = 0x1b;

        public const int COMM_SUCCESS = 0;                   // Communication Success result value
        public const int COMM_TX_FAIL = -1001;               // Communication Tx Failed

        public const int OVERFLOW_2byte = 65536;
        public const uint OVERFLOW_4byte = 4294967295;



        // Initialize PortHandler Structs
        // Set the port path
        // Get methods and members of PortHandlerLinux or PortHandlerWindows
        int port_num;

        // Initialize PacketHandler Structs       

        //flag
        sbyte Connection_state = 0;                                           //0: disconnection 1: Connection
        sbyte Draw_state = 0;                                                 //0:OFF   1:draw
        sbyte go_zero_set = 0;
        sbyte return_state = 0;
        sbyte pressure_cal_initial_flag = 0;
        public sbyte firstrun = 0;
        public sbyte control_state = 0;
        public sbyte AI_flag = 0;
        public sbyte one_back_flag = 0;


        //data buffer/////////////////////////
        public const int Buffer_Size = 50000;
        public string[] current_Buffer = new string[Buffer_Size];
        public string[] pressure_Buffer = new string[Buffer_Size];
        public string[] velocity_Buffer = new string[Buffer_Size];
        public string[] goalcurrent_Buffer = new string[Buffer_Size];
        public string[] goalpressure_Buffer = new string[Buffer_Size];
        public string[] distance_Buffer = new string[Buffer_Size];
        public string[] distance_table = new string[Buffer_Size];
        public string[] current_table = new string[Buffer_Size];
        public double[] Avg_Buffer = new double[100];
        StreamReader sr_1 = new StreamReader("C:/Users/ICG/OneDrive/바탕 화면/motor_test/Motor_test_1/data/distance_table.csv");
        StreamReader sr_2 = new StreamReader("C:/Users/ICG/OneDrive/바탕 화면/motor_test/Motor_test_1/data/current_table.csv");




        public int file_num = 552;
        public int test_file_num = 552;

        public string data_buffer = "Current(mA),Current_filter(mA),Pressure,Velocity(rpm),goal Velocity(rpm), goal Pressure, gapdistance(mm),strain(%) ,position, time(s),Thickness_10g/mm_pressure(0.01mm),cal_current(mA),MUL_COM_state,compressure_number,Thickness_normal,\r";
        public string data_buffer_state = "";

        //present raw data
        public int present_raw_position_data, present_raw_velocity_data;
        public short present_raw_current_data, present_raw_PWM_data;
        public double present_pressure_data = 0;

        //goal data
        public uint goal_Velocity = 0;
        public int goal_Current = 0;
        public int target_Position = 0;
        public uint velocity_trajectory = 0;


        //Limit data
        public int limit_Velocity = 50;//초기값으로 50
        public double limit_current = 70;//초기값으로 70
        public double limit_pressure = 0;


        //graph var
        public uint time = 0;//횟수의 time
        public int save_data_flag = 1;

        public double graph_x;
        public double graph_y_1;
        public double graph_y_2;
        public double graph_y_3;
        Stopwatch stopwatch1 = new Stopwatch(); //객체 선언
        Stopwatch stopwatch2 = new Stopwatch(); //객체 선언

        public double MovAvg_current;


        //calibration var
        public double calibration_buffer = 0;
        public double calibration_result = 0;
        public double initial_state_current = 0;                                       // do work

        public double pressure_model = 0;
        public string pressure_model_text = "";
        public double p1 = 0.000069;
        public double p2 = 0.3165;
        // public double p3 = 39.97;



        //Current control var
        public double previous_time = 0;


        //multicompressure var        
        public double waiting_time = 0;
        public double present_time = 0;
        public double thickness1 = 0;
        public double thickness2 = 0;
        public double strain = 0;
        public int predict_class = 0;
        public double predict_thickness = 0;
        public double multi_limit_current = 0;
        public double stop_indicator = 0;
        public string strain_text = "";
        public int stop_position = 0;
        public int stop_time = 0;
        public int setting_flag = 0;
        public int MUL_COM_state = 0;
        public int compressure_number = 0;
        public int stop_num_flag = 0;
        public int stop_position_databuffer_index = 0;
        public double[] stop_position_databuffer = Enumerable.Repeat<double>(0, 100).ToArray<double>();

        //AI
        public int state_analysis_flag = 0;
        public double stop_pressure = 0;
        public double AI_current_buffer = 0;
        public int next_flag = 0;




        //go_zero_set
        public int zero_point = 0; //완전 압착상태
        public int end_point = 0; //완전 풀림상태

        //distance cal variable
        int present_position = 0;
        int before_position = 0;
        int position_flag = 0;

        int start_position = 0;
        int end_position = 0;

        string gap_distance = "";
        double distance_unit = 0;

        string cal_current = "";
        double cal_current_data = 0;

        //pressure
        public int cal_flag = 0;
        public int data_stop_flag = 0;
        public string pressure_data_buffer = "Current(mA),Position,\r";
        public int pressure_position_1 = 0;
        public int pressure_position_2 = 0;
        public int repeat_num = 0;
        public int cal_velocity = 0;
        public int goal_num_of_repetitions = 10;
        public int present_num_of_repetitions = 1;
        public int max_cal_rpm = 15;//설정값

        public double average = 0;
        public double average_before = 0;
        public int data_number = 1;
        public string average_buffer = "";


        public int distance_cal_flag = 0;
        public int End_Position = 0;
        public int Start_Position = 0;






        public Form1()
        {
            InitializeComponent();

            Chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            COM_SET_DATA.Text = "COM3";
            Baudrate_SET_DATA.SelectedIndex = 2;
            Velocity_limit_input.Text = Convert.ToString(50);
            Current_limit_input.Text = Convert.ToString(70);
            time_num_input.Text = Convert.ToString(150);


            while (!sr_1.EndOfStream)
            {

                // 한 줄씩 읽어온다.

                string line = sr_1.ReadLine();

                // 쉼표( , )를 기준으로 데이터를 분리한다.

                string[] data = line.Split(',');

                for (int i = 0; i < data.Length; i++)
                {
                    distance_table[data.Length - i] = data[i];
                }
            }

            while (!sr_2.EndOfStream)
            {

                // 한 줄씩 읽어온다.

                string line = sr_2.ReadLine();

                // 쉼표( , )를 기준으로 데이터를 분리한다.

                string[] data = line.Split(',');

                for (int i = 0; i < data.Length; i++)
                {
                    current_table[i] = data[i];
                }

            }
            sr_1.Close();
            sr_2.Close();
        }


        //   Function   //
        public void Current_Control()
        {

            switch (control_state)
            {
                case 1:
                    dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, (uint)goal_Velocity);
                    break;


                case 2://do work                   
                    dynamixel.write2ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_CURRENT, (ushort)goal_Current);
                    break;



                case 3:
                    /* case 3 
                     * 초기상태 = 0
                     * 속도로 압축상태 = 1
                     * 위치제어(전류기반)로 압축 상태(실제로 멈춘게 맞는지 확인) = 2
                     * 멈춘 상태(waiting time만큼 대기) = 3
                     * 역회전 상태  = 4
                     * 3회실시하여 멈추는 상태(조건: 4번상태를 3번 도달한 후) = 5
                     */
                    if (1.20 > Convert.ToDouble(gap_distance))
                    {
                        //정지 상태
                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, (ushort)0);
                        dynamixel.write2ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_CURRENT, (ushort)0);
                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)present_raw_position_data);
                        Initial_state();

                        //데이터 쓰기
                        string stringPath = @"../../../data/state_data_buffer/" + "state_data" + Convert.ToString(file_num) + ".csv";
                        File.WriteAllText(stringPath, data_buffer_state);
                        file_num++;

                        //한번에 시행하게 추가-위치이동
                        Thread.Sleep(3000);
                        dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
                        dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 5); // 11-> opration mode adr, 5-> Current based position control
                        Limit_input_setting();
                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 108, 1);
                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 112, velocity_trajectory);
                        dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);

                        control_state = 6;
                        target_Position = 8000;

                    }
                    else
                    {

                        if (MUL_COM_state == 0)
                        {

                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, 10);//velocity(rawdata) = 10으로 진행(2.2rpm)
                            MUL_COM_state = 1;

                        }
                        else if (MUL_COM_state == 1)
                        {

                            if (pressure_model > Convert.ToDouble(Multiple_compression_pressure.Text))
                            {
                                MUL_COM_state = 2;
                            }

                        }
                        else if (MUL_COM_state == 2)
                        {
                            /*
                            stop_position = present_raw_position_data;
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 5); // 11-> opration mode adr, 5-> Current based position control
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);

                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)present_raw_position_data);
                            previous_time = Convert.ToDouble(Time_indicator.Text);
                            MUL_COM_state = 3;//확인바람~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                            */
                            // 데이터 뽑을때 사용
                            
                            if (setting_flag == 0)//초기 위치제어 셋팅 유무
                            {
                                dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
                                dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 5); // 11-> opration mode adr, 5-> Current based position control
                                Current_limit_input.Text = Convert.ToString(Convert.ToInt16(AI_current_buffer * 0.98));
                                Limit_input_setting();
                                dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 108, 1);
                                dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 112, 10);
                                dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);
                                target_Position = Start_Position;
                                dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)target_Position);

                                previous_time = Convert.ToDouble(Time_indicator.Text);
                                setting_flag = 1;
                            }
                            if (setting_flag == 1)
                            {
                                present_time = Convert.ToDouble(Time_indicator.Text);
                                if (dynamixel.read1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 122) == 0)
                                {
                                    stop_num_flag++;
                                }
                                else
                                {
                                    stop_num_flag = 0;
                                    previous_time = Convert.ToDouble(Time_indicator.Text);
                                }
                                if (present_time > previous_time + 3)
                                {
                                    if (stop_num_flag > 3)
                                    {
                                        stop_position = present_raw_position_data;
                                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 108, 0);
                                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 112, 0);
                                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)present_raw_position_data);
                                        previous_time = Convert.ToDouble(Time_indicator.Text);
                                        MUL_COM_state = 3;

                                        if (compressure_number == 0)
                                        {
                                            data_buffer_state = data_buffer;

                                        }
                                    }
                                }
                            }
                        }
                        else if (MUL_COM_state == 3)
                        {
                            present_time = Convert.ToDouble(Time_indicator.Text);

                            if (present_time > (previous_time + (waiting_time * 0.1)))
                            {
                                dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 108, 1);
                                dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 112, 10);
                                MUL_COM_state = 4;
                            }
                        }
                        else if (MUL_COM_state == 4)
                        {
                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)(stop_position - 1024));
                            if (present_raw_position_data < (stop_position - 1014) && present_raw_position_data > (stop_position - 1034))
                            {
                                return_state = 1;
                            }
                            if (return_state == 1)
                            {
                                stop_position_databuffer[stop_position_databuffer_index] = Math.Round(55.21 + 1 - Convert.ToDouble(distance_table[Math.Abs(present_raw_position_data - Start_Position)]), 3);
                                stop_position_databuffer_index++;
                                present_time = 0;
                                stop_position = 0;
                                stop_time = 0;
                                setting_flag = 0;
                                return_state = 0;
                                stop_num_flag = 0;
                                compressure_number++;

                                if (compressure_number > 3)
                                {
                                    if (stop_position_databuffer[stop_position_databuffer_index - 1] > stop_position_databuffer[stop_position_databuffer_index - 2] - 0.1)//이전의 경우 멈춤곳에 비해 0.2mm이상 압축이 안되면 끝
                                    {
                                        MUL_COM_state = 5;
                                    }
                                    else
                                    {
                                        MUL_COM_state = 0;
                                        dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
                                        dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 1); // 11-> opration mode adr, 1-> Velociy controlmode
                                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 44, 10); // 44-> Velocity limit adr, 10 -> Velociy limit 
                                        Limit_input_setting();
                                        dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);
                                    }
                                }
                                else
                                {
                                    MUL_COM_state = 0;
                                    dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
                                    dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 1); // 11-> opration mode adr, 1-> Velociy controlmode
                                    dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 44, 10); // 44-> Velocity limit adr, 10 -> Velociy limit 
                                    Limit_input_setting();
                                    dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);
                                }
                            }
                        }
                        else//MUL_COM_state = 5
                        {
                            compressure_number = 0;
                            control_state = 4;

                            data_buffer_state = data_buffer;
                            string stringPath = @"../../../data/state_data_buffer/" + "state_data" + Convert.ToString(file_num) + ".csv";
                            File.WriteAllText(stringPath, data_buffer_state);
                            file_num++;


                            //한번에 시행하게 추가
                            Thread.Sleep(3000);
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 5); // 11-> opration mode adr, 5-> Current based position control
                            Limit_input_setting();
                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 108, 1);
                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 112, velocity_trajectory);
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);

                            control_state = 6;
                            target_Position = 8000;
                        }
                    }
                    break;


                case 4:
                    dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, (ushort)0);
                    dynamixel.write2ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_CURRENT, (ushort)0);
                    dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)present_raw_position_data);
                    Initial_state();

                    break;


                case 5:
                    if (state_analysis_flag == 0)
                    {
                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, 10);//velocity(rawdata) = 10으로 진행(2.2rpm)
                        state_analysis_flag = 1;
                    }
                    else if (state_analysis_flag == 1)
                    {
                        if (1.8 > Convert.ToDouble(gap_distance))
                        {
                            state_analysis_flag = 2;
                        }
                    }
                    else if (state_analysis_flag == 2)
                    {
                        if (setting_flag == 0)//초기 위치제어 셋팅 유무
                        {
                            Current_limit_input.Text = Convert.ToString(Convert.ToInt16(present_raw_current_data * 0.98));

                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 5); // 11-> opration mode adr, 5-> Current based position control
                            Limit_input_setting();
                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 108, 1);
                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 112, 10);
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);
                            target_Position = Start_Position;
                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)target_Position);

                            previous_time = Convert.ToDouble(Time_indicator.Text);
                            setting_flag = 1;
                        }
                        if (setting_flag == 1)
                        {
                            present_time = Convert.ToDouble(Time_indicator.Text);
                            if (dynamixel.read1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 122) == 0)
                            {
                                stop_num_flag++;
                            }
                            else
                            {
                                stop_num_flag = 0;
                                previous_time = Convert.ToDouble(Time_indicator.Text);
                            }
                            if (present_time > previous_time + 5)
                            {
                                if (stop_num_flag > 5)
                                {
                                    stop_pressure_text.Text = Convert.ToString(pressure_model);
                                    AI_current_buffer = present_raw_current_data;//한번에 시행하게 추가
                                    stop_position = present_raw_position_data;
                                    dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 108, 0);
                                    dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 112, 0);
                                    dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)present_raw_position_data);
                                    previous_time = Convert.ToDouble(Time_indicator.Text);
                                    state_analysis_flag = 3;


                                    data_buffer_state = data_buffer;

                                    string stringPath = @"../../../data/state_data_buffer/" + "AI_state_data" + Convert.ToString(file_num) + ".csv";
                                    File.WriteAllText(stringPath, data_buffer_state);


                                }
                            }
                        }
                    }
                    else if (state_analysis_flag == 3)
                    {
                        setting_flag = 0;
                        state_analysis_flag = 0;
                        stop_num_flag = 0;
                        /////////한번에 시행하게 추가
                        Multiple_compression_pressure.Text = stop_pressure_text.Text;




                        dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
                        dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 5); // 11-> opration mode adr, 5-> Current based position control
                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 108, 1);
                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 112, velocity_trajectory);
                        dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);
                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)27000);

                        while ((int)dynamixel.read4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_PRESENT_POSITION) > 27010)//마진10
                        {

                        }

                        control_state = 3;
                        MULTI_COMPRESSION_SETTING();
                        Thread.Sleep(1000);

                        //매트랩으로부터 모델을 가져와 상태 분류 do work
                    }
                    break;




                case 6:
                    dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)target_Position);
                    break;


                case 7:
                    dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, 10);//velocity(rawdata) = 10으로 진행(2.2rpm)
                    if (strain > 0.41)
                    {
                        AI_current_buffer = present_raw_current_data;
                        string stringPath = @"../../../data/state_data_buffer/temp/data" + Convert.ToString(test_file_num) + ".csv";
                        data_buffer_state = data_buffer;

                        File.WriteAllText(stringPath, data_buffer_state);
                        test_file_num++;
                        control_state = 4;
                    }
                    break;
                case 8:

                    dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, 10);//velocity(rawdata) = 10으로 진행(2.2rpm)

                    if (predict_class == 1)
                    {
                        stop_indicator = predict_thickness - ((predict_thickness - 1.4425) / (1 + 0.1853));
                    }
                    else if (predict_class == 2)
                    {
                        stop_indicator = predict_thickness - ((predict_thickness - 1.5318) / (1 + 0.1862));
                    }
                    else if (predict_class == 3)
                    {
                        stop_indicator = predict_thickness - ((predict_thickness - 1.6212) / (1 + 0.1874));
                    }
                    else if (predict_class == 4)
                    {
                        stop_indicator = predict_thickness - ((predict_thickness - 1.7106) / (1 + 0.1872));
                    }
                    else if (predict_class == 5)
                    {
                        stop_indicator = predict_thickness - ((predict_thickness - 1.8) / (1 + 0.2038));
                    }
                    else//클래스 입력이 1-5 가 아닐때 멈추게.
                    {
                        control_state = 4;
                    }

                    if (Convert.ToDouble(gap_distance) < stop_indicator) //현재 멈춰야하는 곳을 넘는 순간. 해당 지점 압력으로 다중압축 시행
                    {
                        Multiple_compression_pressure.Text = Convert.ToString(pressure_model);
                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, 0);//velocity(rawdata) = 10으로 진행(2.2rpm)
                        
                        Thread.Sleep(3000);

                        waiting_time = Convert.ToDouble(time_num_input.Text);
                        WAITING_TIME_INDICATOR.Text = Convert.ToDouble(waiting_time * 0.1) + "s";
                        multi_limit_current = Convert.ToDouble(Multiple_compression_pressure.Text);
                        thickness1 = Convert.ToDouble(thickness1_input.Text) * 0.01;
                        thickness2 = Convert.ToDouble(thickness2_input.Text) * 0.01;

                        control_state = 3;
                        MULTI_COMPRESSION_SETTING();
                    }
                        break;

                case 9:

                    if (AI_flag == 1)
                    {
                        dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, 10);//velocity(rawdata) = 10으로 진행(2.2rpm)

                        if (strain > 0.41)
                        {
                            AI_current_buffer = present_raw_current_data;
                            string stringPath = @"../../../data/state_data_buffer/temp/data" + Convert.ToString(test_file_num) + ".csv";
                            data_buffer_state = data_buffer;
                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, 0);

                            File.WriteAllText(stringPath, data_buffer_state);
                            test_file_num++;

                            AI_flag = 2;
                            Thread.Sleep(3000);

                        }
                    }
                    else if (AI_flag == 2)
                    {
                        string data_name = "data" + Convert.ToString(test_file_num - 1) + ".csv"; // (test_file_num - 1) : 위에서 저장할때 +1을 했으니 읽을때 -1 을 해야 저장한걸 읽음

                        // Create the MATLAB instance 
                        MLApp.MLApp matlab = new MLApp.MLApp();

                        object result = null;
                        object[] res = null;

                        // Change to the directory where the function is located 
                        matlab.Execute(@"addpath 'C:\Users\ICG\OneDrive\바탕 화면\motor_test\Motor_test_1\data\state_data_buffer\temp'");
                        matlab.Execute(@"addpath 'C:\Temp\myfunc'");

                        // Call the MATLAB function myfunc
                        matlab.Feval("AIalgorithm", 2, out result, data_name);

                        // Display result 
                        res = result as object[];

                        predict_thickness = (double)res[0] / 100;
                        predict_class = (int)res[1];

                        predict_thickness_input.Text = Convert.ToString(predict_thickness * 100);
                        predict_class_input.Text = Convert.ToString(predict_class);
                        AI_flag = 3;
                        matlab.Quit();
                    }
                    else if (AI_flag == 3)
                    {

                        if(one_back_flag == 0)
                        {
                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, OVERFLOW_4byte - 10);//velocity(rawdata) = -10으로 진행(2.2rpm) 반대방향
                            if(strain < 0.35)
                            {
                                one_back_flag = 1;
                            }
                        }
                        else
                        {

                            if (predict_class == 1)
                            {
                                stop_indicator = predict_thickness - ((predict_thickness - 1.4425) / (1 + 0.1853));
                            }
                            else if (predict_class == 2)
                            {
                                stop_indicator = predict_thickness - ((predict_thickness - 1.5318) / (1 + 0.1842));
                            }
                            else if (predict_class == 3)
                            {
                                stop_indicator = predict_thickness - ((predict_thickness - 1.6212) / (1 + 0.1834));
                            }
                            else if (predict_class == 4)
                            {
                                stop_indicator = predict_thickness - ((predict_thickness - 1.7106) / (1 + 0.1842));
                            }
                            else if (predict_class == 5)
                            {
                                stop_indicator = predict_thickness - ((predict_thickness - 1.8) / (1 + 0.2038));
                            }
                            else//클래스 입력이 1-5 가 아닐때 멈추게.
                            {
                                control_state = 4;
                                AI_flag = 0;
                            }

                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, 10);//velocity(rawdata) = 10으로 진행(2.2rpm)

                            if (Convert.ToDouble(gap_distance) < stop_indicator) //현재 멈춰야하는 곳을 넘는 순간. 해당 지점 압력으로 다중압축 시행
                            {
                                Multiple_compression_pressure.Text = Convert.ToString(pressure_model);
                                dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, 0);//velocity(rawdata) = 10으로 진행(2.2rpm)

                                Thread.Sleep(3000);

                                waiting_time = Convert.ToDouble(time_num_input.Text);
                                WAITING_TIME_INDICATOR.Text = Convert.ToDouble(waiting_time * 0.1) + "s";
                                multi_limit_current = Convert.ToDouble(Multiple_compression_pressure.Text);
                                thickness1 = Convert.ToDouble(thickness1_input.Text) * 0.01;
                                thickness2 = Convert.ToDouble(thickness2_input.Text) * 0.01;

                                control_state = 3;
                                MULTI_COMPRESSION_SETTING();
                                AI_flag = 0;
                                one_back_flag = 0;
                            }
                        }  
                    }
                    else
                    {
                        control_state = 4;
                    }       

                    break;
            }

        }

        public void Data_buffer_clear()
        {
            data_buffer = "Current(mA),Current_filter(mA),Pressure,Velocity(rpm),goal Velocity(rpm), goal Pressure, gapdistance(mm),strain(%) ,position, time(s),Thickness_10g/mm_pressure(0.01mm),cal_current(mA),MUL_COM_state,compressure_number,Thickness_normal,\r";
            //데이터만 초기화가 필요한 경우에 사용(현재 미사용)
        }
        public void Initial_state()
        {
            return_state = 0;
            stop_time = 0;
        }

        public void Initial_data_graph()
        {
            data_buffer = "Current(mA),Current_filter(mA),Pressure,Velocity(rpm),goal Velocity(rpm), goal Pressure, gapdistance(mm),strain(%) ,position, time(s),Thickness_10g/mm_pressure(0.01mm),cal_current(mA),MUL_COM_state,compressure_number,Thickness_normal,\r";
            Chart1.Series[0].Points.Clear();
            Chart1.Series[1].Points.Clear();
            Chart1.Series[2].Points.Clear();
            time = 0;
        }

        public void MULTI_COMPRESSION_SETTING()
        {
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 1); // 11-> opration mode adr, 1-> Velociy controlmode
            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 44, 10); // 44-> Velocity limit adr, 10 -> Velociy limit 
            Limit_input_setting();
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);

            Initial_data_graph();
            present_time = 0;
            stop_position = 0;
            stop_time = 0;
            setting_flag = 0;
            return_state = 0;
            stop_num_flag = 0;
            compressure_number = 1;
            MUL_COM_state = 0;
        }
        public double MovAvgFilter(int data)
        {
            int n = 10;

            if (firstrun == 0)
            {
                for (int i = 1; i <= n + 2; i++)
                {
                    Avg_Buffer[i] = data;
                }
                firstrun = 1;
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    Avg_Buffer[i - 1] = Avg_Buffer[i];
                }
                Avg_Buffer[n] = data;
            }

            Avg_Buffer[n + 2] = Avg_Buffer[n + 1] + ((Avg_Buffer[n] - Avg_Buffer[0]) / n);
            Avg_Buffer[n + 1] = Avg_Buffer[n + 2];

            /* n = 3 기준
             * Avg_Buffer[0] = k-n data
             * Avg_Buffer[1] = data
             * Avg_Buffer[2] = data 
             * Avg_Buffer[3] = k data
             * Avg_Buffer[4] = Avg_before (Avg_Buffer[n + 1])
             * Avg_Buffer[5] = Avg(Avg_Buffer[n + 2])
             */


            return Avg_Buffer[n + 2];
        }

        public void Draw_graph()
        {
            if (Draw_state == 1)
            {
                time++;
                graph_x = time;
                graph_y_1 = present_raw_current_data;
                graph_y_2 = MovAvg_current;
                graph_y_3 = pressure_model;


                Chart1.Series[0].Points.AddXY(graph_x, graph_y_1);
                Chart1.Series[1].Points.AddXY(graph_x, graph_y_2);
                Chart1.Series[2].Points.AddXY(graph_x, graph_y_3);

                if (time > 100)
                {
                    Chart1.ChartAreas[0].AxisX.ScaleView.Zoom(time - 100, time);
                }
                else
                {
                    Chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, time);
                }
            }
            else
            {

            }

        }


        public double Calibration_pressure()
        {
            calibration_result = (present_raw_current_data + calibration_buffer - (2 * initial_state_current)) * 0.1;//do work (0.1-> 100ms)
            calibration_buffer = present_raw_current_data;

            return calibration_result;
        }

        public void Disconnection_function()
        {
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
            Connection_state = 0;
        }

        public void Limit_input_setting()
        {
            double pressure_offset = Math.Round((Convert.ToDouble(current_table[Math.Abs(present_raw_position_data - End_Position)])), 3);

            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);

            limit_Velocity = Convert.ToInt32(Velocity_limit_input.Text);
            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 44, (ushort)limit_Velocity);
            VELOCITY_LIMIT_INDICATOR.Text = Convert.ToString(dynamixel.read4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 44) * 0.229) + "rpm";

            limit_current = Convert.ToInt16(Current_limit_input.Text);
            dynamixel.write2ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 38, (ushort)limit_current);

            if ((present_raw_position_data - End_Position < 24000 && (present_raw_position_data - End_Position) > 0) && (End_Position != Start_Position))
            {
                limit_pressure = Math.Round((p1 * (limit_current - pressure_offset) * (limit_current - pressure_offset)) + (p2 * (limit_current - pressure_offset)), 4);
                if (limit_pressure < 0)
                {
                    limit_pressure = 0;
                }
                PRESSURE_LIMIT_INDICATOR.Text = Convert.ToString(limit_pressure) + "g/mm \r" + Convert.ToString(dynamixel.read2ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 38) * 2.690) + "mA";
            }
            else
            {
                PRESSURE_LIMIT_INDICATOR.Text = "pressure: " + "g/mm \r" + Convert.ToString(dynamixel.read2ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 38) * 2.690) + "mA";
            }


            VELOCITY_LIMIT_INDICATOR.Text = Convert.ToString(0.229 * limit_Velocity);
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);
        }




        //   Button   //

        private void CONNECTION_BUTTION_Click(object sender, EventArgs e)
        {
            DEVICENAME = COM_SET_DATA.Text;
            port_num = dynamixel.portHandler(DEVICENAME);

            //
            dynamixel.packetHandler();
            dynamixel.openPort(port_num);
            dynamixel.setBaudRate(port_num, BAUDRATE);

            // Operation mode change sequence :  TORQUE_DISABLE  ->  Change Operation mode (Causion: The mode cannot be changed until the torque is turned off)
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 1); // 11-> opration mode adr, 1-> Velociy controlmode
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 10, 0);// addr 10: Drive mode[0 ~ 7]  , data 0: normalmode  ex) data 1: reverse mode
            // Enable Dynamixel Torque
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);

            Connection_state = 1;
            Draw_state = 1;

            Limit_input_setting();
        }

        private void CONTINUE_PRESSURE_BUTTON_Click(object sender, EventArgs e)
        {
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 1); // 11-> opration mode adr, 1-> Velociy controlmode
            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 44, 300); // 44-> Velocity limit adr, 300 -> Velociy limit 68.7RPM(최대 234.267 RPM까지 가능하지만 68.7로 제한을 걸어둠)
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);

            control_state = 1;

            //임시
            //data_buffer = "Current(mA),Current_filter(mA),Pressure,Velocity(rpm),goal Velocity(rpm), goal Pressure, gapdistance(mm),strain(%) ,position, time(s),Thickness(0.01mm),\r";
        }
        private void Current_hold_BUTTON_Click(object sender, EventArgs e)
        {
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 0); // 11-> opration mode adr, 0-> Current controlmode
            dynamixel.write2ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 38, 1000); // 38-> Current limit adr, 500 -> Current limit 2.67A(최대 5.5A까지 가능하지만 2.69A로 제한을 걸어둠)
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);

            control_state = 2;
        }

        private void MULTI_COMPRESSION_BUTTON_Click(object sender, EventArgs e)
        {
            control_state = 3;
            MULTI_COMPRESSION_SETTING();
        }



        private void Position_button_Click(object sender, EventArgs e)
        {
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 5); // 11-> opration mode adr, 5-> Current based position control
            Limit_input_setting();
            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 108, 1);
            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 112, velocity_trajectory);
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);


            control_state = 6;
        }


        private void STOP_BUTTON_Click(object sender, EventArgs e)
        {
            control_state = 4;
            cal_flag = 0;
        }


        private void Disconnection_BUTTION_Click(object sender, EventArgs e)//Disconnection button 따로 필요없을꺼 같아서 일단은 지워둠
        {
            Disconnection_function();
        }             

        private void CHANGE_DIRECTION_BUTTON_Click(object sender, EventArgs e)
        {
            int direction_type;
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
            direction_type = dynamixel.read1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 10);//addr 10: Drive mode[0~7]

            if (direction_type == 0)
            {
                dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 10, 1);
            }
            else
            {
                dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 10, 0);
            }

            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);
        }

        private void GRAPH_RESET_BUTTON_Click(object sender, EventArgs e)
        {
            Chart1.Series[0].Points.Clear();
            Chart1.Series[1].Points.Clear();
            Chart1.Series[2].Points.Clear();
            time = 0;
            Initial_data_graph();
        }

        private void GRAPH_STOP_RESUME_BUTTON_Click(object sender, EventArgs e)
        {
            if (Draw_state == 0)
            {
                Draw_state = 1;
                save_data_flag = 1;
            }
            else
            {
                Draw_state = 0;
                save_data_flag = 0;
            }

        }

        private void gap_distance_ready_button_Click(object sender, EventArgs e)
        {
            int setting_position = 0;            
            setting_position = present_raw_position_data - (present_raw_position_data - (4090 * (present_raw_position_data / 4090))) + 720;


            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 5); // 11-> opration mode adr, 5-> Current based position control
            Limit_input_setting();
            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 108, 1);
            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 112, 10);
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);

            target_Position = setting_position;

            Start_Position_indicator.Text = Convert.ToString(target_Position);
            End_Position_indicator.Text = Convert.ToString(target_Position - 24000);

            Start_Position = Convert.ToInt32(Start_Position_indicator.Text);
            End_Position = Convert.ToInt32(End_Position_indicator.Text);
            control_state = 6;

        }

        private void PARAMETER_SETTING_BUTTON_Click(object sender, EventArgs e)
        {
            Limit_input_setting();
        }

        private void PRESSURE_LIMIT_SET_BUTTON_Click(object sender, EventArgs e)
        {

        }

        private void SAVE_DATA_BUTTON_Click(object sender, EventArgs e)
        {
            string stringPath = @"../../../data/data storage/data" + Convert.ToString(file_num) + ".csv";
            File.WriteAllText(stringPath, data_buffer);
            file_num++;
        }


        //   Timer   //
        private void TIMER1_Tick(object sender, EventArgs e)
        {
            /*
             * p1 = -6.9e-05 0.000069
             * p2 = 0.3165
             * p3 = 39.97
             * 
             */

            if (Connection_state == 1)
            {
                //get raw data from dynamixel motor
                present_raw_current_data = (short)dynamixel.read2ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_PRRESENT_CURRENT);
                present_raw_position_data = (int)dynamixel.read4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_PRESENT_POSITION);
                present_raw_velocity_data = (int)dynamixel.read4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_PRRESENT_VELOCITY);

                MovAvg_current = MovAvgFilter(present_raw_current_data);


                //임시
                /*
                if(control_state == 6)
                {

                }
                else
                {
                    if (present_raw_position_data > 29000)
                    {
                        if(control_state == 1)
                        {
                            string stringPath = @"../../../data/data storage/data" + Convert.ToString(file_num) + ".csv";
                            File.WriteAllText(stringPath, data_buffer);
                            file_num++;
                            data_buffer = "Current(mA),Current_filter(mA),Pressure,Velocity(rpm),goal Velocity(rpm), goal Pressure, gapdistance(mm),strain(%) ,position, time(s),Thickness(0.01mm),\r";
                        }
                        control_state = 4;

                    }
                }
                */
                //

                //gap distance
                if((present_raw_position_data - End_Position < 24000 && (present_raw_position_data - End_Position) > 0) && (End_Position != Start_Position))
                {                    
                    gap_distance = Convert.ToString(Math.Round(55.21 + 1 - Convert.ToDouble(distance_table[Math.Abs(present_raw_position_data - Start_Position)]), 3));
                    if(Convert.ToDouble(gap_distance) > thickness2)
                    {
                        strain = 0;
                        strain_text = Convert.ToString(strain);
                    }
                    else
                    {
                        strain = (thickness2 - Convert.ToDouble(gap_distance)) / thickness2;
                        strain_text = Convert.ToString(strain);
                    }                    
                }
                else if (End_Position == Start_Position)
                {
                    gap_distance = "need calibration";
                    strain_text = "need calibration";
                }
                else if(present_raw_position_data - End_Position > 24000 || (present_raw_position_data - End_Position) < 0)
                {
                    gap_distance = " out of range";
                    strain_text = " out of range";
                }
                else
                {
                    gap_distance = "error";
                    strain_text = " out of range";
                }

                ///////////////////////////////////////////////////////////
                if ((present_raw_position_data - End_Position < 24000 && (present_raw_position_data - End_Position) > 0) && (End_Position != Start_Position))
                {
                    //cal_current = Convert.ToString(Math.Round(Math.Abs(present_raw_current_data) - (Convert.ToDouble(current_table[Math.Abs(present_raw_position_data - End_Position)])),3));
                    cal_current = Convert.ToString(Math.Round(Math.Abs(MovAvg_current) - (Convert.ToDouble(current_table[Math.Abs(present_raw_position_data - End_Position)])), 3));
                    cal_current_data = Convert.ToDouble(cal_current);
                    pressure_model = Math.Round(((p1 * cal_current_data * cal_current_data) + (p2 * cal_current_data))* 3.044, 4);
                    

                    
                    if (pressure_model < 0)
                    {
                        pressure_model = 0;
                    }
                    pressure_model_text = Convert.ToString(pressure_model);
                }
                else if (End_Position == Start_Position)
                {
                    pressure_model_text = "need calibration";
                }
                else if (present_raw_position_data - End_Position > 24000 || (present_raw_position_data - End_Position) < 0)
                {
                    pressure_model_text = " out of range";
                }
                else
                {
                    pressure_model_text = "error";
                }

                

                //check time
                stopwatch1.Stop();
                Time_indicator.Text = Convert.ToString((double)(stopwatch1.ElapsedMilliseconds)/1000);//시간 정확한지 
                stopwatch1.Start();


                if (distance_cal_flag == 1)
                {
                    End_Position = Convert.ToInt32(End_Position_indicator.Text);
                    if (present_raw_position_data < End_Position + 30 && present_raw_position_data > End_Position - 30)
                    {
                        string stringPath = @"../../../data/data" + "distance_cal" + Convert.ToString(distance_cal_flag) + ".csv";
                        File.WriteAllText(stringPath, data_buffer);

                        previous_time = Convert.ToDouble(Time_indicator.Text);


                        distance_cal_flag = 2;
                        control_state = 4;
                        goal_Velocity = 10;
                    }
                }
                else if (distance_cal_flag == 2)
                {
                    present_time = Convert.ToDouble(Time_indicator.Text);
                    Start_Position = Convert.ToInt32(Start_Position_indicator.Text);
                    if (present_time > previous_time + 5)
                    {
                        if (control_state == 4)
                        {
                            Initial_data_graph();
                        }
                        control_state = 1;
                        if (present_raw_position_data < Start_Position + 30 && present_raw_position_data > Start_Position - 30)
                        {
                            string stringPath = @"../../../data/data" + "distance_cal" + Convert.ToString(distance_cal_flag) + ".csv";
                            File.WriteAllText(stringPath, data_buffer);

                            control_state = 4;
                            distance_cal_flag = 0;
                            goal_Velocity = 0;
                        }
                    }
                }

                //raw data  indicator
                Raw_Position_indicator.Text = Convert.ToString(present_raw_position_data);
                Raw_current_indicatior.Text = Convert.ToString(present_raw_current_data);
                Raw_Velocity_indicator.Text = Convert.ToString(present_raw_velocity_data);

                //application indicator
                Position_indicator.Text = Convert.ToString(present_raw_position_data * 0.088);//단위: * 0.088도
                Current_indicator.Text = Convert.ToString(present_raw_current_data * 2.690);//단위:  * 2.69mA
                Velocity_indicator.Text = Convert.ToString(present_raw_velocity_data * 0.229);//단위: * 0.229rpm //do work 나중에 문합기의 velocity로 변경생각
                Pressure_indicator.Text = pressure_model_text;
                Gap_distance_indicator.Text = (gap_distance);//단위: mm
                strain_indicator.Text = strain_text;


                //draw graph function
                Draw_graph();


                //data save to buffer
                if (save_data_flag == 1)
                {
                    /*
                    data_buffer += Current_indicator.Text + ",";//current
                    data_buffer += Convert.ToString(MovAvg_current * 2.69) + ",";//current_filter
                    data_buffer += Pressure_indicator.Text + ",";//pressure
                    data_buffer += Velocity_indicator.Text + ",";//velocity
                    data_buffer += Convert.ToString(goal_Velocity) + ",";//goal Velocity
                    data_buffer += "prepare" + ",";//goal pressure
                    data_buffer += Gap_distance_indicator.Text + ",";//gap_distance
                    data_buffer += strain_text + ",";//strain
                    data_buffer += Position_indicator.Text + ",";//position
                    data_buffer += Time_indicator.Text + ",";//time
                    data_buffer += thickness_input.Text + "\r";//thickness1
                    */

                    data_buffer += Current_indicator.Text + ",";//current
                    data_buffer += Convert.ToString(MovAvg_current * 2.69) + ",";//current_filter
                    data_buffer += Pressure_indicator.Text + ",";//pressure
                    data_buffer += Velocity_indicator.Text + ",";//velocity
                    data_buffer += Convert.ToString(goal_Velocity) + ",";//goal Velocity
                    data_buffer += "prepare" + ",";//goal pressure
                    data_buffer += Gap_distance_indicator.Text + ",";//gap_distance
                    data_buffer += strain_text + ",";//strain
                    data_buffer += Position_indicator.Text + ",";//position
                    data_buffer += Time_indicator.Text + ",";//time
                    data_buffer += thickness1_input.Text + ",";//thickness1
                    data_buffer += Convert.ToString(cal_current_data) + ",";//cal_current


                    if (control_state == 3)
                    {
                        data_buffer += Convert.ToString(MUL_COM_state) + ",";
                     }
                    else
                    {
                        data_buffer += "No_M_compressure" + ",";
                    }
                    data_buffer += Convert.ToString(compressure_number) + ",";
                    data_buffer += thickness2_input.Text + "," + "\r";//thickness2

                }
            }

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(cal_flag == 0)//압력calibreation동안 안겹치게
            {
                Current_Control();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (max_cal_rpm >= cal_velocity)
            {

                if (present_num_of_repetitions <= goal_num_of_repetitions)
                {
                    if (cal_flag == 1)
                    {
                        pressure_position_1 = Convert.ToInt32(pressure_cal_start_position.Text);

                        if (pressure_cal_initial_flag == 0)//처음 시행시 속도 값 셋팅
                        {
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 5); // 11-> opration mode adr, 5-> Current based position control
                            Current_limit_input.Text = Convert.ToString(300);
                            Limit_input_setting();
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);
                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)pressure_position_1);

                            if (present_raw_position_data < pressure_position_1 + 20 && present_raw_position_data > pressure_position_1 - 20)
                            {
                                dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
                                dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 1); // 11-> opration mode adr, 1-> Velociy controlmode
                                dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);
                                dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, (ushort)cal_velocity);
                            }

                            pressure_cal_initial_flag = 1;
                        }

                        if (pressure_position_1 + 200 < present_raw_position_data)//현재속도(present_raw_velocity_data)가 셋팅한 속도값(cal_velocity)에 도달하는 경우 데이터저장 시작(cal_flag = 2)
                        {
                            pressure_data_buffer = "Current(mA),Position,\r";
                            pressure_position_2 = present_raw_position_data;
                            cal_flag = 2;
                        }
                        /*
                        if (present_raw_velocity_data == cal_velocity)//현재속도(present_raw_velocity_data)가 셋팅한 속도값(cal_velocity)에 도달하는 경우 데이터저장 시작(cal_flag = 2)
                        {
                            pressure_data_buffer = "Current(mA),Position,\r";
                            pressure_position_2 = present_raw_position_data;
                            cal_flag = 2;
                        }
                        */

                    }
                    else if (cal_flag == 2)
                    {
                        if(data_stop_flag == 0)
                        {
                            pressure_data_buffer += Current_indicator.Text + ",";
                            pressure_data_buffer += Raw_Position_indicator.Text + "\r";//time

                            average_before = average;
                            average = ((data_number - 1) * average_before + present_raw_current_data) / data_number;    //raw data (need * 2.69 mA)                   
                            data_number++;
                        }
                        else
                        {

                        }

                        if (pressure_position_2 + 2045 <= present_raw_position_data)//4090이 한봐퀴인데 한바퀴를 돌아버리면 고정시키는것?에 닿아 전류가 증가해버림
                        {
                            data_stop_flag = 1;
                        }

                            if (present_raw_current_data > 1700)// 2.69A이상 전류 흐르게되면 멈추게
                        {
                            control_state = 4;
                            cal_flag = 0;
                            present_num_of_repetitions = 0;

                            pressure_data_buffer += "\r\r" + average;
                            string stringPath = @"../../../data/pressure data" + Convert.ToString(file_num) +"_"+ Convert.ToString(cal_velocity) + ".csv";
                            File.WriteAllText(stringPath, pressure_data_buffer);
                            file_num++;
                        }

                        if (pressure_position_2 + (2045 + 350) <= present_raw_position_data)//4090이 한봐퀴인데 한바퀴를 돌아버리면 고정시키는것?에 닿아 전류가 증가해버림
                        {
                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_VELOCITY, (ushort)0);
                            dynamixel.write2ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_CURRENT, (ushort)0);
                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)present_raw_position_data);

                            average_buffer += Convert.ToString(average * 2.69) + ",";
                            data_stop_flag = 0;
                            cal_flag = 3;
                            pressure_data_buffer += "\r\r" + average;
                            string stringPath = @"../../../data/pressure data" + Convert.ToString(file_num) + "_" + Convert.ToString(cal_velocity) + ".csv";
                            File.WriteAllText(stringPath, pressure_data_buffer);
                            file_num++;

                            Thread.Sleep(3000);
                        }
                    }
                    else if (cal_flag == 3)
                    {
                        if (pressure_cal_initial_flag == 1)
                        {
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 5); // 11-> opration mode adr, 5-> Current based position control
                            Current_limit_input.Text = Convert.ToString(200);
                            Limit_input_setting(); //전류제한 걸어둠(천천히 풀리게)
                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 108, 10);
                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 112, 30);
                            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);

                            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)pressure_position_1);
                            pressure_cal_initial_flag = 2;
                        }

                        if (present_raw_position_data < pressure_position_1 + 5 && present_raw_position_data > pressure_position_1 - 5)
                        {
                            Thread.Sleep(3000);
                            if(present_raw_position_data < pressure_position_1 + 20 && present_raw_position_data > pressure_position_1 - 20)
                            {

                                pressure_cal_initial_flag = 0;
                                present_num_of_repetitions++;
                                cal_flag = 1;

                                average = 0;
                                average_before = 0;
                                data_number = 1;
                            }
                            else
                            {
                                dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_GOAL_POSITION, (ushort)pressure_position_1);
                            }

                        }
                    }
                }
                else
                {
                    average_buffer += "," + "," + "rpm" + Convert.ToString(cal_velocity) + "\r";

                    present_num_of_repetitions = 1;
                    cal_velocity++;
                    pressure_cal_velocity.Text = Convert.ToString(cal_velocity);
                }
            }
            else
            {
                string stringPath = @"../../../data/pressure data" + "Total_average" + "_" + ".csv";
                File.WriteAllText(stringPath, average_buffer);
                control_state = 4;
                cal_flag = 0;
                present_num_of_repetitions = 1;
                pressure_cal_initial_flag = 0;
            }

        }
        //   TEXT   //
        private void RAW_Position_TEXT_Click(object sender, EventArgs e)
        {

        }

        private void Current_TEXT_Click(object sender, EventArgs e)
        {

        }

        private void Velocity_TEXT_Click(object sender, EventArgs e)
        {

        }

        private void RAW_velocity_TEXT_Click(object sender, EventArgs e)
        {

        }

        private void Pressure_TEXT_Click(object sender, EventArgs e)
        {

        }

        private void RAW_CURRENT_TEXT_Click(object sender, EventArgs e)
        {

        }
        private void Velocity_limit_text_Click(object sender, EventArgs e)
        {

        }

        private void Current_limit_text_Click(object sender, EventArgs e)
        {

        }



        //   Indicator   //
        private void Raw_Position_indicator_Click(object sender, EventArgs e)
        {

        }

        private void Raw_Velocity_indicator_Click(object sender, EventArgs e)
        {

        }

        private void Velocity_indicator_Click(object sender, EventArgs e)
        {

        }

        private void Current_indicator_Click(object sender, EventArgs e)
        {

        }

        private void Raw_current_indicatior_Click(object sender, EventArgs e)
        {

        }

        private void Pressure_indicator_Click(object sender, EventArgs e)
        {

        }

 
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void VELOCITY_LIMIT_INDICATOR_Click(object sender, EventArgs e)
        {
            
        }

        private void time_num_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void time_num_input_text_Click(object sender, EventArgs e)
        {

        }

        private void WAITING_TIME_INDICATOR_Click(object sender, EventArgs e)
        {

        }

        private void Target_velocity_set_button_Click(object sender, EventArgs e)
        {
            goal_Velocity = Convert.ToUInt32(target_velocity_input.Text);
        }

        private void Target_current_set_button_Click(object sender, EventArgs e)
        {
            goal_Current = Convert.ToInt32(target_current_input.Text);
        }

        private void Target_position_set_button_Click(object sender, EventArgs e)
        {
            target_Position = Convert.ToInt32(target_position_input.Text);
            velocity_trajectory = Convert.ToUInt32(rpm_position_input.Text);
        }

        private void TIME_TEXT_Click(object sender, EventArgs e)
        {

        }

        private void Time_indicator_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Gap_distance_indicator_Click(object sender, EventArgs e)
        {

        }


        private void target_current_input_ValueChanged(object sender, EventArgs e)
        {
            Target_current_indicator.Text = Convert.ToString((Convert.ToDouble(target_current_input.Text) * 2.69)) + " mA";
        }

        private void target_velocity_input_ValueChanged(object sender, EventArgs e)
        {
            Target_velocity_indicator.Text = Convert.ToString((Convert.ToDouble(target_velocity_input.Text) * 0.229)) + " RPM";
        }

        private void target_position_input_ValueChanged(object sender, EventArgs e)
        {
            Target_position_indicator.Text = Convert.ToString((Convert.ToDouble(target_position_input.Text) * 0.088)) + " °";
        }

        private void Target_position_indicator_Click(object sender, EventArgs e)
        {

        }

        private void Position_indicator_Click(object sender, EventArgs e)
        {

        }

        private void Current_limit_input_text_Click(object sender, EventArgs e)
        {

        }

        private void Pressure_limit_input_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Velocity_limit_input_ValueChanged(object sender, EventArgs e)
        {

        }

        private void time_num_input_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void Multiple_compression_set_button_Click(object sender, EventArgs e)
        {
            waiting_time = Convert.ToDouble(time_num_input.Text);            
            WAITING_TIME_INDICATOR.Text = Convert.ToDouble(waiting_time * 0.1) + "s";
            multi_limit_current = Convert.ToDouble(Multiple_compression_pressure.Text);
            thickness1 = Convert.ToDouble(thickness1_input.Text) * 0.01;
            thickness2 = Convert.ToDouble(thickness2_input.Text) * 0.01;
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void pressure_cal_button_Click(object sender, EventArgs e)
        {
            cal_flag = 1; 
        }

        private void pressure_cal_velocity_ValueChanged(object sender, EventArgs e)
        {
            cal_velocity = Convert.ToInt32(pressure_cal_velocity.Text);
        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PRESSURE_LIMIT_INDICATOR_Click(object sender, EventArgs e)
        {
            
        }

        //   Other   //

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Connection_state == 1)
            {
                Disconnection_function();
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gap_distance_start_button_Click(object sender, EventArgs e)
        {
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 1); // 11-> opration mode adr, 1-> Velociy controlmode
            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 44, 60); // 44-> Velocity limit adr, 300 -> Velociy limit 68.7RPM(최대 234.267 RPM까지 가능하지만 68.7로 제한을 걸어둠)
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);


            Initial_data_graph();
            control_state = 1;
            distance_cal_flag = 1;

            goal_Velocity = (OVERFLOW_4byte - 9);//10의 속도

            /*
             * cal_flag = 1
                //여는 상황
                일정한 속도 10으로 시작 prsent_position이 end position에 도달 하면 멈춤
                멈추면 데이터 저장 후 5초간 대기
                그후  cal_flag = 2
                cal_flag = 2
                //닫는 상황
                일정한 속도 10으로 시작prsent_position이 start position에 도달하면 멈춤
                멈추면 데이터 저장 후 5초간 대기
                그 후 cal_flag = 0       
             */
        }

        private void Start_Position_indicator_Click(object sender, EventArgs e)
        {

        }

        private void End_Position_indicator_Click(object sender, EventArgs e)
        {

        }

        private void groupBox12_Enter_1(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void thickness_text_Click(object sender, EventArgs e)
        {

        }

        private void state_analysis_button_Click(object sender, EventArgs e)
        {
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 1); // 11-> opration mode adr, 1-> Velociy controlmode
            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 44, 10); // 44-> Velocity limit adr, 10 -> Velociy limit 
            Limit_input_setting();
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);

            state_analysis_flag = 0;
            control_state = 5;

            Initial_data_graph();

            //
            next_flag = 1;
            present_time = 0;
            stop_position = 0;
            stop_time = 0;
            setting_flag = 0;
            return_state = 0;
            stop_num_flag = 0;
            compressure_number = 1;
            MUL_COM_state = 0;
            stop_position_databuffer = Enumerable.Repeat<double>(0, 100).ToArray<double>();
            stop_position_databuffer_index = 0;
    }

        private void stop_pressure_text_Click(object sender, EventArgs e)
        {

        }

        private void thickness2_input_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_DISABLE);
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 11, 1); // 11-> opration mode adr, 1-> Velociy controlmode
            dynamixel.write4ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, 44, 10); // 44-> Velocity limit adr, 10 -> Velociy limit 
            Limit_input_setting();
            dynamixel.write1ByteTxRx(port_num, PROTOCOL_VERSION, DXL_ID, ADDR_PRO_TORQUE_ENABLE, TORQUE_ENABLE);
            AI_flag = 1;
            control_state = 9;

            //control_state = 7;
            Data_buffer_clear();
            Initial_data_graph();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_2(object sender, EventArgs e)
        {

        }

        private void predict_class_analysis_Click(object sender, EventArgs e)
        {
            /*predict_thickness = Convert.ToDouble(predict_thickness_input.Text) / 100;
            predict_class = Convert.ToInt16(predict_class_input.Text);
            control_state = 8;*/   

        }

        private void AI_set_button_Click(object sender, EventArgs e)
        {
            predict_thickness = Convert.ToDouble(predict_thickness_input.Text) / 100;
            predict_class = Convert.ToInt16(predict_class_input.Text);
            control_state = 8;
        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void Baudrate_SET_DATA_SelectedIndexChanged(object sender, EventArgs e)
        {
            BAUDRATE = Convert.ToInt32(Baudrate_SET_DATA.SelectedItem.ToString());
        }


    }
}
