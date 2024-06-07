namespace Motor_test_1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.CONNECTION_BUTTION = new System.Windows.Forms.Button();
            this.CONTINUE_PRESSURE_BUTTON = new System.Windows.Forms.Button();
            this.RAW_Position_TEXT = new System.Windows.Forms.Label();
            this.Current_TEXT = new System.Windows.Forms.Label();
            this.Velocity_TEXT = new System.Windows.Forms.Label();
            this.RAW_velocity_TEXT = new System.Windows.Forms.Label();
            this.Raw_Position_indicator = new System.Windows.Forms.Label();
            this.Current_indicator = new System.Windows.Forms.Label();
            this.Velocity_indicator = new System.Windows.Forms.Label();
            this.Raw_Velocity_indicator = new System.Windows.Forms.Label();
            this.TIMER1 = new System.Windows.Forms.Timer(this.components);
            this.CHANGE_DIRECTION_BUTTON = new System.Windows.Forms.Button();
            this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Raw_current_indicatior = new System.Windows.Forms.Label();
            this.RAW_CURRENT_TEXT = new System.Windows.Forms.Label();
            this.Pressure_indicator = new System.Windows.Forms.Label();
            this.Pressure_TEXT = new System.Windows.Forms.Label();
            this.GRAPH_RESET_BUTTON = new System.Windows.Forms.Button();
            this.GRAPH_STOP_RESUME_BUTTON = new System.Windows.Forms.Button();
            this.Current_hold_BUTTON = new System.Windows.Forms.Button();
            this.SAVE_DATA_BUTTON = new System.Windows.Forms.Button();
            this.MULTI_COMPRESSION_BUTTON = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Time_indicator = new System.Windows.Forms.Label();
            this.TIME_TEXT = new System.Windows.Forms.Label();
            this.gap_distance_ready_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PRESSURE_LIMIT_INDICATOR = new System.Windows.Forms.Label();
            this.Pressure_limit_text = new System.Windows.Forms.Label();
            this.VELOCITY_LIMIT_INDICATOR = new System.Windows.Forms.Label();
            this.Velocity_limit_text = new System.Windows.Forms.Label();
            this.WAITING_TIME_INDICATOR = new System.Windows.Forms.Label();
            this.Waiting_time_text = new System.Windows.Forms.Label();
            this.pressure_limit_input_text = new System.Windows.Forms.Label();
            this.Velocity_limit_input_text = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Current_limit_input = new System.Windows.Forms.NumericUpDown();
            this.Velocity_limit_input = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PARAMETER_SETTING_BUTTON = new System.Windows.Forms.Button();
            this.time_num_input = new System.Windows.Forms.NumericUpDown();
            this.time_num_input_text = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.COM_SET_DATA = new System.Windows.Forms.TextBox();
            this.Baudrate_SET_DATA = new System.Windows.Forms.ComboBox();
            this.Baudrate_Text = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.COM_TEXT = new System.Windows.Forms.Label();
            this.STOP_BUTTON = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rpm_position_text = new System.Windows.Forms.Label();
            this.rpm_position_input = new System.Windows.Forms.NumericUpDown();
            this.TIMER2 = new System.Windows.Forms.Timer(this.components);
            this.target_velocity_input = new System.Windows.Forms.NumericUpDown();
            this.TARGET_VELOCITY_TEXT = new System.Windows.Forms.Label();
            this.Target_velocity_set_button = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Position_text = new System.Windows.Forms.Label();
            this.Position_indicator = new System.Windows.Forms.Label();
            this.gap_distance_text = new System.Windows.Forms.Label();
            this.Gap_distance_indicator = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.Target_current_indicator = new System.Windows.Forms.Label();
            this.Target_current_set_button = new System.Windows.Forms.Button();
            this.target_current_input = new System.Windows.Forms.NumericUpDown();
            this.TARGET_CURRENT_TEXT = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.Target_position_set_button = new System.Windows.Forms.Button();
            this.Target_position_indicator = new System.Windows.Forms.Label();
            this.target_position_input = new System.Windows.Forms.NumericUpDown();
            this.TARGET_POSITION_TEXT = new System.Windows.Forms.Label();
            this.Position_button = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.Target_velocity_indicator = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.thickness2_text = new System.Windows.Forms.Label();
            this.thickness2_input = new System.Windows.Forms.NumericUpDown();
            this.thickness1_text = new System.Windows.Forms.Label();
            this.thickness1_input = new System.Windows.Forms.NumericUpDown();
            this.Strain_text = new System.Windows.Forms.Label();
            this.strain_indicator = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Multiple_compression_pressure = new System.Windows.Forms.NumericUpDown();
            this.Multiple_compression_set_button = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.gap_distance_start_button = new System.Windows.Forms.Button();
            this.end_position_text = new System.Windows.Forms.Label();
            this.Start_Position_indicator = new System.Windows.Forms.Label();
            this.start_position_text = new System.Windows.Forms.Label();
            this.End_Position_indicator = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.pressure_cal_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pressure_cal_start_position = new System.Windows.Forms.NumericUpDown();
            this.pressure_cal_velocity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.TIMER3 = new System.Windows.Forms.Timer(this.components);
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.predict_thickness_input = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.predict_class_input = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.stop_pressure_text = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.state_indicator = new System.Windows.Forms.Label();
            this.state_text = new System.Windows.Forms.Label();
            this.state_analysis_button = new System.Windows.Forms.Button();
            this.AI_set_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Current_limit_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Velocity_limit_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_num_input)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpm_position_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.target_velocity_input)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.target_current_input)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.target_position_input)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thickness2_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thickness1_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Multiple_compression_pressure)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pressure_cal_start_position)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressure_cal_velocity)).BeginInit();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.predict_thickness_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.predict_class_input)).BeginInit();
            this.SuspendLayout();
            // 
            // CONNECTION_BUTTION
            // 
            this.CONNECTION_BUTTION.Location = new System.Drawing.Point(12, 142);
            this.CONNECTION_BUTTION.Name = "CONNECTION_BUTTION";
            this.CONNECTION_BUTTION.Size = new System.Drawing.Size(100, 35);
            this.CONNECTION_BUTTION.TabIndex = 0;
            this.CONNECTION_BUTTION.Text = "Connection";
            this.CONNECTION_BUTTION.UseVisualStyleBackColor = true;
            this.CONNECTION_BUTTION.Click += new System.EventHandler(this.CONNECTION_BUTTION_Click);
            // 
            // CONTINUE_PRESSURE_BUTTON
            // 
            this.CONTINUE_PRESSURE_BUTTON.Location = new System.Drawing.Point(6, 20);
            this.CONTINUE_PRESSURE_BUTTON.Name = "CONTINUE_PRESSURE_BUTTON";
            this.CONTINUE_PRESSURE_BUTTON.Size = new System.Drawing.Size(100, 35);
            this.CONTINUE_PRESSURE_BUTTON.TabIndex = 1;
            this.CONTINUE_PRESSURE_BUTTON.Text = "Continue  pressure";
            this.CONTINUE_PRESSURE_BUTTON.UseVisualStyleBackColor = true;
            this.CONTINUE_PRESSURE_BUTTON.Click += new System.EventHandler(this.CONTINUE_PRESSURE_BUTTON_Click);
            // 
            // RAW_Position_TEXT
            // 
            this.RAW_Position_TEXT.AutoSize = true;
            this.RAW_Position_TEXT.Location = new System.Drawing.Point(935, 30);
            this.RAW_Position_TEXT.Name = "RAW_Position_TEXT";
            this.RAW_Position_TEXT.Size = new System.Drawing.Size(50, 12);
            this.RAW_Position_TEXT.TabIndex = 2;
            this.RAW_Position_TEXT.Text = "Position";
            this.RAW_Position_TEXT.Click += new System.EventHandler(this.RAW_Position_TEXT_Click);
            // 
            // Current_TEXT
            // 
            this.Current_TEXT.AutoSize = true;
            this.Current_TEXT.Location = new System.Drawing.Point(7, 48);
            this.Current_TEXT.Name = "Current_TEXT";
            this.Current_TEXT.Size = new System.Drawing.Size(75, 12);
            this.Current_TEXT.TabIndex = 3;
            this.Current_TEXT.Text = "Current(mA)";
            this.Current_TEXT.Click += new System.EventHandler(this.Current_TEXT_Click);
            // 
            // Velocity_TEXT
            // 
            this.Velocity_TEXT.AutoSize = true;
            this.Velocity_TEXT.Location = new System.Drawing.Point(8, 108);
            this.Velocity_TEXT.Name = "Velocity_TEXT";
            this.Velocity_TEXT.Size = new System.Drawing.Size(82, 12);
            this.Velocity_TEXT.TabIndex = 4;
            this.Velocity_TEXT.Text = "Velocity(rpm)";
            this.Velocity_TEXT.Click += new System.EventHandler(this.Velocity_TEXT_Click);
            // 
            // RAW_velocity_TEXT
            // 
            this.RAW_velocity_TEXT.AutoSize = true;
            this.RAW_velocity_TEXT.Location = new System.Drawing.Point(27, 146);
            this.RAW_velocity_TEXT.Name = "RAW_velocity_TEXT";
            this.RAW_velocity_TEXT.Size = new System.Drawing.Size(48, 12);
            this.RAW_velocity_TEXT.TabIndex = 5;
            this.RAW_velocity_TEXT.Text = "velocity";
            this.RAW_velocity_TEXT.Click += new System.EventHandler(this.RAW_velocity_TEXT_Click);
            // 
            // Raw_Position_indicator
            // 
            this.Raw_Position_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Raw_Position_indicator.Location = new System.Drawing.Point(999, 20);
            this.Raw_Position_indicator.Name = "Raw_Position_indicator";
            this.Raw_Position_indicator.Size = new System.Drawing.Size(101, 37);
            this.Raw_Position_indicator.TabIndex = 7;
            this.Raw_Position_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Raw_Position_indicator.Click += new System.EventHandler(this.Raw_Position_indicator_Click);
            // 
            // Current_indicator
            // 
            this.Current_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Current_indicator.Location = new System.Drawing.Point(96, 38);
            this.Current_indicator.Name = "Current_indicator";
            this.Current_indicator.Size = new System.Drawing.Size(101, 37);
            this.Current_indicator.TabIndex = 8;
            this.Current_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Current_indicator.Click += new System.EventHandler(this.Current_indicator_Click);
            // 
            // Velocity_indicator
            // 
            this.Velocity_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Velocity_indicator.Location = new System.Drawing.Point(96, 99);
            this.Velocity_indicator.Name = "Velocity_indicator";
            this.Velocity_indicator.Size = new System.Drawing.Size(101, 37);
            this.Velocity_indicator.TabIndex = 9;
            this.Velocity_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Velocity_indicator.Click += new System.EventHandler(this.Velocity_indicator_Click);
            // 
            // Raw_Velocity_indicator
            // 
            this.Raw_Velocity_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Raw_Velocity_indicator.Location = new System.Drawing.Point(99, 134);
            this.Raw_Velocity_indicator.Name = "Raw_Velocity_indicator";
            this.Raw_Velocity_indicator.Size = new System.Drawing.Size(101, 37);
            this.Raw_Velocity_indicator.TabIndex = 10;
            this.Raw_Velocity_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Raw_Velocity_indicator.Click += new System.EventHandler(this.Raw_Velocity_indicator_Click);
            // 
            // TIMER1
            // 
            this.TIMER1.Enabled = true;
            this.TIMER1.Interval = 55;
            this.TIMER1.Tick += new System.EventHandler(this.TIMER1_Tick);
            // 
            // CHANGE_DIRECTION_BUTTON
            // 
            this.CHANGE_DIRECTION_BUTTON.Location = new System.Drawing.Point(780, 330);
            this.CHANGE_DIRECTION_BUTTON.Name = "CHANGE_DIRECTION_BUTTON";
            this.CHANGE_DIRECTION_BUTTON.Size = new System.Drawing.Size(112, 39);
            this.CHANGE_DIRECTION_BUTTON.TabIndex = 13;
            this.CHANGE_DIRECTION_BUTTON.Text = "change direction";
            this.CHANGE_DIRECTION_BUTTON.UseVisualStyleBackColor = true;
            this.CHANGE_DIRECTION_BUTTON.Click += new System.EventHandler(this.CHANGE_DIRECTION_BUTTON_Click);
            // 
            // Chart1
            // 
            chartArea2.AxisX.ScaleView.Size = 100D;
            chartArea2.Name = "ChartArea1";
            this.Chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Chart1.Legends.Add(legend2);
            this.Chart1.Location = new System.Drawing.Point(186, 12);
            this.Chart1.Name = "Chart1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Current";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "filter_current";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "pressure";
            this.Chart1.Series.Add(series4);
            this.Chart1.Series.Add(series5);
            this.Chart1.Series.Add(series6);
            this.Chart1.Size = new System.Drawing.Size(694, 165);
            this.Chart1.SuppressExceptions = true;
            this.Chart1.TabIndex = 14;
            this.Chart1.Text = "chart1";
            this.Chart1.UseWaitCursor = true;
            this.Chart1.Click += new System.EventHandler(this.Chart1_Click);
            // 
            // Raw_current_indicatior
            // 
            this.Raw_current_indicatior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Raw_current_indicatior.Location = new System.Drawing.Point(999, 80);
            this.Raw_current_indicatior.Name = "Raw_current_indicatior";
            this.Raw_current_indicatior.Size = new System.Drawing.Size(101, 37);
            this.Raw_current_indicatior.TabIndex = 16;
            this.Raw_current_indicatior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Raw_current_indicatior.Click += new System.EventHandler(this.Raw_current_indicatior_Click);
            // 
            // RAW_CURRENT_TEXT
            // 
            this.RAW_CURRENT_TEXT.AutoSize = true;
            this.RAW_CURRENT_TEXT.Location = new System.Drawing.Point(931, 90);
            this.RAW_CURRENT_TEXT.Name = "RAW_CURRENT_TEXT";
            this.RAW_CURRENT_TEXT.Size = new System.Drawing.Size(44, 12);
            this.RAW_CURRENT_TEXT.TabIndex = 15;
            this.RAW_CURRENT_TEXT.Text = "current";
            this.RAW_CURRENT_TEXT.Click += new System.EventHandler(this.RAW_CURRENT_TEXT_Click);
            // 
            // Pressure_indicator
            // 
            this.Pressure_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pressure_indicator.Location = new System.Drawing.Point(96, 155);
            this.Pressure_indicator.Name = "Pressure_indicator";
            this.Pressure_indicator.Size = new System.Drawing.Size(101, 37);
            this.Pressure_indicator.TabIndex = 19;
            this.Pressure_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Pressure_indicator.Click += new System.EventHandler(this.Pressure_indicator_Click);
            // 
            // Pressure_TEXT
            // 
            this.Pressure_TEXT.AutoSize = true;
            this.Pressure_TEXT.Location = new System.Drawing.Point(26, 166);
            this.Pressure_TEXT.Name = "Pressure_TEXT";
            this.Pressure_TEXT.Size = new System.Drawing.Size(56, 12);
            this.Pressure_TEXT.TabIndex = 18;
            this.Pressure_TEXT.Text = "Pressure";
            this.Pressure_TEXT.Click += new System.EventHandler(this.Pressure_TEXT_Click);
            // 
            // GRAPH_RESET_BUTTON
            // 
            this.GRAPH_RESET_BUTTON.Location = new System.Drawing.Point(782, 240);
            this.GRAPH_RESET_BUTTON.Name = "GRAPH_RESET_BUTTON";
            this.GRAPH_RESET_BUTTON.Size = new System.Drawing.Size(112, 30);
            this.GRAPH_RESET_BUTTON.TabIndex = 20;
            this.GRAPH_RESET_BUTTON.Text = "graph reset";
            this.GRAPH_RESET_BUTTON.UseVisualStyleBackColor = true;
            this.GRAPH_RESET_BUTTON.Click += new System.EventHandler(this.GRAPH_RESET_BUTTON_Click);
            // 
            // GRAPH_STOP_RESUME_BUTTON
            // 
            this.GRAPH_STOP_RESUME_BUTTON.Location = new System.Drawing.Point(782, 200);
            this.GRAPH_STOP_RESUME_BUTTON.Name = "GRAPH_STOP_RESUME_BUTTON";
            this.GRAPH_STOP_RESUME_BUTTON.Size = new System.Drawing.Size(112, 30);
            this.GRAPH_STOP_RESUME_BUTTON.TabIndex = 21;
            this.GRAPH_STOP_RESUME_BUTTON.Text = "stop / resume";
            this.GRAPH_STOP_RESUME_BUTTON.UseVisualStyleBackColor = true;
            this.GRAPH_STOP_RESUME_BUTTON.Click += new System.EventHandler(this.GRAPH_STOP_RESUME_BUTTON_Click);
            // 
            // Current_hold_BUTTON
            // 
            this.Current_hold_BUTTON.Location = new System.Drawing.Point(6, 20);
            this.Current_hold_BUTTON.Name = "Current_hold_BUTTON";
            this.Current_hold_BUTTON.Size = new System.Drawing.Size(100, 35);
            this.Current_hold_BUTTON.TabIndex = 22;
            this.Current_hold_BUTTON.Text = "current hold";
            this.Current_hold_BUTTON.UseVisualStyleBackColor = true;
            this.Current_hold_BUTTON.Click += new System.EventHandler(this.Current_hold_BUTTON_Click);
            // 
            // SAVE_DATA_BUTTON
            // 
            this.SAVE_DATA_BUTTON.Location = new System.Drawing.Point(780, 280);
            this.SAVE_DATA_BUTTON.Name = "SAVE_DATA_BUTTON";
            this.SAVE_DATA_BUTTON.Size = new System.Drawing.Size(112, 30);
            this.SAVE_DATA_BUTTON.TabIndex = 24;
            this.SAVE_DATA_BUTTON.Text = "save data";
            this.SAVE_DATA_BUTTON.UseVisualStyleBackColor = true;
            this.SAVE_DATA_BUTTON.Click += new System.EventHandler(this.SAVE_DATA_BUTTON_Click);
            // 
            // MULTI_COMPRESSION_BUTTON
            // 
            this.MULTI_COMPRESSION_BUTTON.Location = new System.Drawing.Point(165, 154);
            this.MULTI_COMPRESSION_BUTTON.Name = "MULTI_COMPRESSION_BUTTON";
            this.MULTI_COMPRESSION_BUTTON.Size = new System.Drawing.Size(100, 35);
            this.MULTI_COMPRESSION_BUTTON.TabIndex = 25;
            this.MULTI_COMPRESSION_BUTTON.Text = "Multi compression";
            this.MULTI_COMPRESSION_BUTTON.UseVisualStyleBackColor = true;
            this.MULTI_COMPRESSION_BUTTON.Click += new System.EventHandler(this.MULTI_COMPRESSION_BUTTON_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Raw_Velocity_indicator);
            this.groupBox1.Controls.Add(this.RAW_velocity_TEXT);
            this.groupBox1.Location = new System.Drawing.Point(900, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 200);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "raw data";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Time_indicator
            // 
            this.Time_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Time_indicator.Location = new System.Drawing.Point(96, 258);
            this.Time_indicator.Name = "Time_indicator";
            this.Time_indicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Time_indicator.Size = new System.Drawing.Size(101, 37);
            this.Time_indicator.TabIndex = 52;
            this.Time_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Time_indicator.Click += new System.EventHandler(this.Time_indicator_Click);
            // 
            // TIME_TEXT
            // 
            this.TIME_TEXT.AutoSize = true;
            this.TIME_TEXT.Location = new System.Drawing.Point(32, 268);
            this.TIME_TEXT.Name = "TIME_TEXT";
            this.TIME_TEXT.Size = new System.Drawing.Size(34, 12);
            this.TIME_TEXT.TabIndex = 51;
            this.TIME_TEXT.Text = "Time";
            this.TIME_TEXT.Click += new System.EventHandler(this.TIME_TEXT_Click);
            // 
            // gap_distance_ready_button
            // 
            this.gap_distance_ready_button.Location = new System.Drawing.Point(3, 38);
            this.gap_distance_ready_button.Name = "gap_distance_ready_button";
            this.gap_distance_ready_button.Size = new System.Drawing.Size(53, 35);
            this.gap_distance_ready_button.TabIndex = 27;
            this.gap_distance_ready_button.Text = "ready";
            this.gap_distance_ready_button.UseVisualStyleBackColor = true;
            this.gap_distance_ready_button.Click += new System.EventHandler(this.gap_distance_ready_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PRESSURE_LIMIT_INDICATOR);
            this.groupBox2.Controls.Add(this.Pressure_limit_text);
            this.groupBox2.Controls.Add(this.VELOCITY_LIMIT_INDICATOR);
            this.groupBox2.Controls.Add(this.Velocity_limit_text);
            this.groupBox2.Location = new System.Drawing.Point(655, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(115, 186);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Limit";
            // 
            // PRESSURE_LIMIT_INDICATOR
            // 
            this.PRESSURE_LIMIT_INDICATOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PRESSURE_LIMIT_INDICATOR.Location = new System.Drawing.Point(6, 98);
            this.PRESSURE_LIMIT_INDICATOR.Name = "PRESSURE_LIMIT_INDICATOR";
            this.PRESSURE_LIMIT_INDICATOR.Size = new System.Drawing.Size(101, 44);
            this.PRESSURE_LIMIT_INDICATOR.TabIndex = 31;
            this.PRESSURE_LIMIT_INDICATOR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PRESSURE_LIMIT_INDICATOR.Click += new System.EventHandler(this.PRESSURE_LIMIT_INDICATOR_Click);
            // 
            // Pressure_limit_text
            // 
            this.Pressure_limit_text.AutoSize = true;
            this.Pressure_limit_text.Location = new System.Drawing.Point(8, 81);
            this.Pressure_limit_text.Name = "Pressure_limit_text";
            this.Pressure_limit_text.Size = new System.Drawing.Size(56, 12);
            this.Pressure_limit_text.TabIndex = 30;
            this.Pressure_limit_text.Text = "Pressure";
            this.Pressure_limit_text.Click += new System.EventHandler(this.Current_limit_text_Click);
            // 
            // VELOCITY_LIMIT_INDICATOR
            // 
            this.VELOCITY_LIMIT_INDICATOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VELOCITY_LIMIT_INDICATOR.Location = new System.Drawing.Point(6, 38);
            this.VELOCITY_LIMIT_INDICATOR.Name = "VELOCITY_LIMIT_INDICATOR";
            this.VELOCITY_LIMIT_INDICATOR.Size = new System.Drawing.Size(101, 21);
            this.VELOCITY_LIMIT_INDICATOR.TabIndex = 29;
            this.VELOCITY_LIMIT_INDICATOR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.VELOCITY_LIMIT_INDICATOR.Click += new System.EventHandler(this.VELOCITY_LIMIT_INDICATOR_Click);
            // 
            // Velocity_limit_text
            // 
            this.Velocity_limit_text.AutoSize = true;
            this.Velocity_limit_text.Location = new System.Drawing.Point(8, 23);
            this.Velocity_limit_text.Name = "Velocity_limit_text";
            this.Velocity_limit_text.Size = new System.Drawing.Size(82, 12);
            this.Velocity_limit_text.TabIndex = 28;
            this.Velocity_limit_text.Text = "Velocity(rpm)";
            this.Velocity_limit_text.Click += new System.EventHandler(this.Velocity_limit_text_Click);
            // 
            // WAITING_TIME_INDICATOR
            // 
            this.WAITING_TIME_INDICATOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WAITING_TIME_INDICATOR.Location = new System.Drawing.Point(164, 39);
            this.WAITING_TIME_INDICATOR.Name = "WAITING_TIME_INDICATOR";
            this.WAITING_TIME_INDICATOR.Size = new System.Drawing.Size(101, 21);
            this.WAITING_TIME_INDICATOR.TabIndex = 33;
            this.WAITING_TIME_INDICATOR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WAITING_TIME_INDICATOR.Click += new System.EventHandler(this.WAITING_TIME_INDICATOR_Click);
            // 
            // Waiting_time_text
            // 
            this.Waiting_time_text.AutoSize = true;
            this.Waiting_time_text.Location = new System.Drawing.Point(164, 20);
            this.Waiting_time_text.Name = "Waiting_time_text";
            this.Waiting_time_text.Size = new System.Drawing.Size(73, 12);
            this.Waiting_time_text.TabIndex = 32;
            this.Waiting_time_text.Text = "Waiting time";
            // 
            // pressure_limit_input_text
            // 
            this.pressure_limit_input_text.AutoSize = true;
            this.pressure_limit_input_text.Location = new System.Drawing.Point(3, 81);
            this.pressure_limit_input_text.Name = "pressure_limit_input_text";
            this.pressure_limit_input_text.Size = new System.Drawing.Size(107, 12);
            this.pressure_limit_input_text.TabIndex = 33;
            this.pressure_limit_input_text.Text = "Current(Pressure)";
            this.pressure_limit_input_text.Click += new System.EventHandler(this.Current_limit_input_text_Click);
            // 
            // Velocity_limit_input_text
            // 
            this.Velocity_limit_input_text.AutoSize = true;
            this.Velocity_limit_input_text.Location = new System.Drawing.Point(4, 25);
            this.Velocity_limit_input_text.Name = "Velocity_limit_input_text";
            this.Velocity_limit_input_text.Size = new System.Drawing.Size(82, 12);
            this.Velocity_limit_input_text.TabIndex = 32;
            this.Velocity_limit_input_text.Text = "Velocity(rpm)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Current_limit_input);
            this.groupBox3.Controls.Add(this.Velocity_limit_input);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.pressure_limit_input_text);
            this.groupBox3.Controls.Add(this.PARAMETER_SETTING_BUTTON);
            this.groupBox3.Controls.Add(this.Velocity_limit_input_text);
            this.groupBox3.Location = new System.Drawing.Point(529, 200);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 186);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Limit input";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // Current_limit_input
            // 
            this.Current_limit_input.Location = new System.Drawing.Point(6, 98);
            this.Current_limit_input.Maximum = new decimal(new int[] {
            2047,
            0,
            0,
            0});
            this.Current_limit_input.Name = "Current_limit_input";
            this.Current_limit_input.Size = new System.Drawing.Size(101, 21);
            this.Current_limit_input.TabIndex = 46;
            this.Current_limit_input.ValueChanged += new System.EventHandler(this.Pressure_limit_input_ValueChanged);
            // 
            // Velocity_limit_input
            // 
            this.Velocity_limit_input.Location = new System.Drawing.Point(6, 40);
            this.Velocity_limit_input.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.Velocity_limit_input.Name = "Velocity_limit_input";
            this.Velocity_limit_input.Size = new System.Drawing.Size(101, 21);
            this.Velocity_limit_input.TabIndex = 45;
            this.Velocity_limit_input.ValueChanged += new System.EventHandler(this.Velocity_limit_input_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(437, 259);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(101, 37);
            this.textBox1.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-312, -118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "set";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-314, -132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 12);
            this.label3.TabIndex = 37;
            this.label3.Text = "Velocity(rpm)";
            // 
            // PARAMETER_SETTING_BUTTON
            // 
            this.PARAMETER_SETTING_BUTTON.Location = new System.Drawing.Point(12, 150);
            this.PARAMETER_SETTING_BUTTON.Name = "PARAMETER_SETTING_BUTTON";
            this.PARAMETER_SETTING_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.PARAMETER_SETTING_BUTTON.TabIndex = 35;
            this.PARAMETER_SETTING_BUTTON.Text = "set";
            this.PARAMETER_SETTING_BUTTON.UseVisualStyleBackColor = true;
            this.PARAMETER_SETTING_BUTTON.Click += new System.EventHandler(this.PARAMETER_SETTING_BUTTON_Click);
            // 
            // time_num_input
            // 
            this.time_num_input.Location = new System.Drawing.Point(8, 39);
            this.time_num_input.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.time_num_input.Name = "time_num_input";
            this.time_num_input.Size = new System.Drawing.Size(101, 21);
            this.time_num_input.TabIndex = 47;
            this.time_num_input.ValueChanged += new System.EventHandler(this.time_num_input_ValueChanged);
            // 
            // time_num_input_text
            // 
            this.time_num_input_text.AutoSize = true;
            this.time_num_input_text.Location = new System.Drawing.Point(6, 20);
            this.time_num_input_text.Name = "time_num_input_text";
            this.time_num_input_text.Size = new System.Drawing.Size(73, 12);
            this.time_num_input_text.TabIndex = 40;
            this.time_num_input_text.Text = "Waiting time";
            this.time_num_input_text.Click += new System.EventHandler(this.time_num_input_text_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.COM_SET_DATA);
            this.groupBox4.Controls.Add(this.Baudrate_SET_DATA);
            this.groupBox4.Controls.Add(this.Baudrate_Text);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.COM_TEXT);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(152, 116);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Connection";
            // 
            // COM_SET_DATA
            // 
            this.COM_SET_DATA.Location = new System.Drawing.Point(6, 36);
            this.COM_SET_DATA.Name = "COM_SET_DATA";
            this.COM_SET_DATA.Size = new System.Drawing.Size(121, 21);
            this.COM_SET_DATA.TabIndex = 30;
            // 
            // Baudrate_SET_DATA
            // 
            this.Baudrate_SET_DATA.FormattingEnabled = true;
            this.Baudrate_SET_DATA.Items.AddRange(new object[] {
            "9600",
            "57600",
            "115200",
            "1000000",
            "2000000",
            "3000000",
            "4000000",
            "4500000"});
            this.Baudrate_SET_DATA.Location = new System.Drawing.Point(6, 85);
            this.Baudrate_SET_DATA.Name = "Baudrate_SET_DATA";
            this.Baudrate_SET_DATA.Size = new System.Drawing.Size(121, 20);
            this.Baudrate_SET_DATA.TabIndex = 44;
            this.Baudrate_SET_DATA.SelectedIndexChanged += new System.EventHandler(this.Baudrate_SET_DATA_SelectedIndexChanged);
            // 
            // Baudrate_Text
            // 
            this.Baudrate_Text.AutoSize = true;
            this.Baudrate_Text.Location = new System.Drawing.Point(6, 68);
            this.Baudrate_Text.Name = "Baudrate_Text";
            this.Baudrate_Text.Size = new System.Drawing.Size(55, 12);
            this.Baudrate_Text.TabIndex = 43;
            this.Baudrate_Text.Text = "Baudrate";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(755, 412);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(101, 37);
            this.textBox2.TabIndex = 39;
            // 
            // COM_TEXT
            // 
            this.COM_TEXT.AutoSize = true;
            this.COM_TEXT.Location = new System.Drawing.Point(6, 21);
            this.COM_TEXT.Name = "COM_TEXT";
            this.COM_TEXT.Size = new System.Drawing.Size(34, 12);
            this.COM_TEXT.TabIndex = 40;
            this.COM_TEXT.Text = "COM";
            this.COM_TEXT.Click += new System.EventHandler(this.label5_Click);
            // 
            // STOP_BUTTON
            // 
            this.STOP_BUTTON.Location = new System.Drawing.Point(6, 22);
            this.STOP_BUTTON.Name = "STOP_BUTTON";
            this.STOP_BUTTON.Size = new System.Drawing.Size(100, 35);
            this.STOP_BUTTON.TabIndex = 30;
            this.STOP_BUTTON.Text = "Stop";
            this.STOP_BUTTON.UseVisualStyleBackColor = true;
            this.STOP_BUTTON.Click += new System.EventHandler(this.STOP_BUTTON_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rpm_position_text);
            this.groupBox5.Controls.Add(this.rpm_position_input);
            this.groupBox5.Controls.Add(this.STOP_BUTTON);
            this.groupBox5.Location = new System.Drawing.Point(12, 200);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(114, 186);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Function";
            // 
            // rpm_position_text
            // 
            this.rpm_position_text.AutoSize = true;
            this.rpm_position_text.Location = new System.Drawing.Point(6, 81);
            this.rpm_position_text.Name = "rpm_position_text";
            this.rpm_position_text.Size = new System.Drawing.Size(81, 12);
            this.rpm_position_text.TabIndex = 54;
            this.rpm_position_text.Text = "rpm(position)";
            // 
            // rpm_position_input
            // 
            this.rpm_position_input.Location = new System.Drawing.Point(8, 99);
            this.rpm_position_input.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rpm_position_input.Name = "rpm_position_input";
            this.rpm_position_input.Size = new System.Drawing.Size(101, 21);
            this.rpm_position_input.TabIndex = 55;
            // 
            // TIMER2
            // 
            this.TIMER2.Enabled = true;
            this.TIMER2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // target_velocity_input
            // 
            this.target_velocity_input.Location = new System.Drawing.Point(8, 87);
            this.target_velocity_input.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.target_velocity_input.Minimum = new decimal(new int[] {
            1023,
            0,
            0,
            -2147483648});
            this.target_velocity_input.Name = "target_velocity_input";
            this.target_velocity_input.Size = new System.Drawing.Size(101, 21);
            this.target_velocity_input.TabIndex = 50;
            this.target_velocity_input.ValueChanged += new System.EventHandler(this.target_velocity_input_ValueChanged);
            // 
            // TARGET_VELOCITY_TEXT
            // 
            this.TARGET_VELOCITY_TEXT.AutoSize = true;
            this.TARGET_VELOCITY_TEXT.Location = new System.Drawing.Point(6, 70);
            this.TARGET_VELOCITY_TEXT.Name = "TARGET_VELOCITY_TEXT";
            this.TARGET_VELOCITY_TEXT.Size = new System.Drawing.Size(88, 12);
            this.TARGET_VELOCITY_TEXT.TabIndex = 49;
            this.TARGET_VELOCITY_TEXT.Text = "Target velocity";
            // 
            // Target_velocity_set_button
            // 
            this.Target_velocity_set_button.Location = new System.Drawing.Point(8, 150);
            this.Target_velocity_set_button.Name = "Target_velocity_set_button";
            this.Target_velocity_set_button.Size = new System.Drawing.Size(75, 23);
            this.Target_velocity_set_button.TabIndex = 48;
            this.Target_velocity_set_button.Text = "set";
            this.Target_velocity_set_button.UseVisualStyleBackColor = true;
            this.Target_velocity_set_button.Click += new System.EventHandler(this.Target_velocity_set_button_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.Position_text);
            this.groupBox6.Controls.Add(this.Position_indicator);
            this.groupBox6.Controls.Add(this.gap_distance_text);
            this.groupBox6.Controls.Add(this.Gap_distance_indicator);
            this.groupBox6.Controls.Add(this.Time_indicator);
            this.groupBox6.Controls.Add(this.TIME_TEXT);
            this.groupBox6.Controls.Add(this.Current_TEXT);
            this.groupBox6.Controls.Add(this.Velocity_TEXT);
            this.groupBox6.Controls.Add(this.Current_indicator);
            this.groupBox6.Controls.Add(this.Velocity_indicator);
            this.groupBox6.Controls.Add(this.Pressure_TEXT);
            this.groupBox6.Controls.Add(this.Pressure_indicator);
            this.groupBox6.Location = new System.Drawing.Point(900, 222);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(218, 375);
            this.groupBox6.TabIndex = 53;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "data";
            this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 12);
            this.label5.TabIndex = 57;
            this.label5.Text = "(mm)";
            // 
            // Position_text
            // 
            this.Position_text.AutoSize = true;
            this.Position_text.Location = new System.Drawing.Point(27, 221);
            this.Position_text.Name = "Position_text";
            this.Position_text.Size = new System.Drawing.Size(50, 12);
            this.Position_text.TabIndex = 55;
            this.Position_text.Text = "Position";
            // 
            // Position_indicator
            // 
            this.Position_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Position_indicator.Location = new System.Drawing.Point(96, 209);
            this.Position_indicator.Name = "Position_indicator";
            this.Position_indicator.Size = new System.Drawing.Size(101, 37);
            this.Position_indicator.TabIndex = 56;
            this.Position_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Position_indicator.Click += new System.EventHandler(this.Position_indicator_Click);
            // 
            // gap_distance_text
            // 
            this.gap_distance_text.AutoSize = true;
            this.gap_distance_text.Location = new System.Drawing.Point(2, 319);
            this.gap_distance_text.Name = "gap_distance_text";
            this.gap_distance_text.Size = new System.Drawing.Size(80, 12);
            this.gap_distance_text.TabIndex = 53;
            this.gap_distance_text.Text = "Gap distance";
            // 
            // Gap_distance_indicator
            // 
            this.Gap_distance_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Gap_distance_indicator.Location = new System.Drawing.Point(96, 307);
            this.Gap_distance_indicator.Name = "Gap_distance_indicator";
            this.Gap_distance_indicator.Size = new System.Drawing.Size(101, 37);
            this.Gap_distance_indicator.TabIndex = 54;
            this.Gap_distance_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Gap_distance_indicator.Click += new System.EventHandler(this.Gap_distance_indicator_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.Target_current_indicator);
            this.groupBox7.Controls.Add(this.Target_current_set_button);
            this.groupBox7.Controls.Add(this.target_current_input);
            this.groupBox7.Controls.Add(this.TARGET_CURRENT_TEXT);
            this.groupBox7.Controls.Add(this.Current_hold_BUTTON);
            this.groupBox7.Location = new System.Drawing.Point(132, 200);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(120, 186);
            this.groupBox7.TabIndex = 54;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Current control";
            // 
            // Target_current_indicator
            // 
            this.Target_current_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Target_current_indicator.Location = new System.Drawing.Point(8, 121);
            this.Target_current_indicator.Name = "Target_current_indicator";
            this.Target_current_indicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Target_current_indicator.Size = new System.Drawing.Size(101, 21);
            this.Target_current_indicator.TabIndex = 58;
            this.Target_current_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Target_current_set_button
            // 
            this.Target_current_set_button.Location = new System.Drawing.Point(8, 150);
            this.Target_current_set_button.Name = "Target_current_set_button";
            this.Target_current_set_button.Size = new System.Drawing.Size(75, 23);
            this.Target_current_set_button.TabIndex = 51;
            this.Target_current_set_button.Text = "set";
            this.Target_current_set_button.UseVisualStyleBackColor = true;
            this.Target_current_set_button.Click += new System.EventHandler(this.Target_current_set_button_Click);
            // 
            // target_current_input
            // 
            this.target_current_input.Location = new System.Drawing.Point(8, 87);
            this.target_current_input.Maximum = new decimal(new int[] {
            2047,
            0,
            0,
            0});
            this.target_current_input.Minimum = new decimal(new int[] {
            2047,
            0,
            0,
            -2147483648});
            this.target_current_input.Name = "target_current_input";
            this.target_current_input.Size = new System.Drawing.Size(101, 21);
            this.target_current_input.TabIndex = 51;
            this.target_current_input.ValueChanged += new System.EventHandler(this.target_current_input_ValueChanged);
            // 
            // TARGET_CURRENT_TEXT
            // 
            this.TARGET_CURRENT_TEXT.AutoSize = true;
            this.TARGET_CURRENT_TEXT.Location = new System.Drawing.Point(6, 70);
            this.TARGET_CURRENT_TEXT.Name = "TARGET_CURRENT_TEXT";
            this.TARGET_CURRENT_TEXT.Size = new System.Drawing.Size(84, 12);
            this.TARGET_CURRENT_TEXT.TabIndex = 51;
            this.TARGET_CURRENT_TEXT.Text = "Target current";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.Target_position_set_button);
            this.groupBox8.Controls.Add(this.Target_position_indicator);
            this.groupBox8.Controls.Add(this.target_position_input);
            this.groupBox8.Controls.Add(this.TARGET_POSITION_TEXT);
            this.groupBox8.Controls.Add(this.Position_button);
            this.groupBox8.Location = new System.Drawing.Point(384, 200);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(139, 186);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Position control";
            // 
            // Target_position_set_button
            // 
            this.Target_position_set_button.Location = new System.Drawing.Point(6, 150);
            this.Target_position_set_button.Name = "Target_position_set_button";
            this.Target_position_set_button.Size = new System.Drawing.Size(75, 23);
            this.Target_position_set_button.TabIndex = 58;
            this.Target_position_set_button.Text = "set";
            this.Target_position_set_button.UseVisualStyleBackColor = true;
            this.Target_position_set_button.Click += new System.EventHandler(this.Target_position_set_button_Click);
            // 
            // Target_position_indicator
            // 
            this.Target_position_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Target_position_indicator.Location = new System.Drawing.Point(8, 121);
            this.Target_position_indicator.Name = "Target_position_indicator";
            this.Target_position_indicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Target_position_indicator.Size = new System.Drawing.Size(101, 21);
            this.Target_position_indicator.TabIndex = 58;
            this.Target_position_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Target_position_indicator.Click += new System.EventHandler(this.Target_position_indicator_Click);
            // 
            // target_position_input
            // 
            this.target_position_input.Increment = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.target_position_input.Location = new System.Drawing.Point(6, 88);
            this.target_position_input.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.target_position_input.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.target_position_input.Name = "target_position_input";
            this.target_position_input.Size = new System.Drawing.Size(101, 21);
            this.target_position_input.TabIndex = 58;
            this.target_position_input.ValueChanged += new System.EventHandler(this.target_position_input_ValueChanged);
            // 
            // TARGET_POSITION_TEXT
            // 
            this.TARGET_POSITION_TEXT.AutoSize = true;
            this.TARGET_POSITION_TEXT.Location = new System.Drawing.Point(6, 70);
            this.TARGET_POSITION_TEXT.Name = "TARGET_POSITION_TEXT";
            this.TARGET_POSITION_TEXT.Size = new System.Drawing.Size(89, 12);
            this.TARGET_POSITION_TEXT.TabIndex = 58;
            this.TARGET_POSITION_TEXT.Text = "Target position";
            // 
            // Position_button
            // 
            this.Position_button.Location = new System.Drawing.Point(6, 20);
            this.Position_button.Name = "Position_button";
            this.Position_button.Size = new System.Drawing.Size(100, 35);
            this.Position_button.TabIndex = 32;
            this.Position_button.Text = "Position";
            this.Position_button.UseVisualStyleBackColor = true;
            this.Position_button.Click += new System.EventHandler(this.Position_button_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.Target_velocity_indicator);
            this.groupBox9.Controls.Add(this.CONTINUE_PRESSURE_BUTTON);
            this.groupBox9.Controls.Add(this.target_velocity_input);
            this.groupBox9.Controls.Add(this.Target_velocity_set_button);
            this.groupBox9.Controls.Add(this.TARGET_VELOCITY_TEXT);
            this.groupBox9.Location = new System.Drawing.Point(258, 200);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(120, 186);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Velocity control";
            this.groupBox9.Enter += new System.EventHandler(this.groupBox9_Enter);
            // 
            // Target_velocity_indicator
            // 
            this.Target_velocity_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Target_velocity_indicator.Location = new System.Drawing.Point(8, 121);
            this.Target_velocity_indicator.Name = "Target_velocity_indicator";
            this.Target_velocity_indicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Target_velocity_indicator.Size = new System.Drawing.Size(101, 21);
            this.Target_velocity_indicator.TabIndex = 57;
            this.Target_velocity_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.thickness2_text);
            this.groupBox10.Controls.Add(this.thickness2_input);
            this.groupBox10.Controls.Add(this.thickness1_text);
            this.groupBox10.Controls.Add(this.thickness1_input);
            this.groupBox10.Controls.Add(this.Strain_text);
            this.groupBox10.Controls.Add(this.strain_indicator);
            this.groupBox10.Controls.Add(this.label1);
            this.groupBox10.Controls.Add(this.Multiple_compression_pressure);
            this.groupBox10.Controls.Add(this.MULTI_COMPRESSION_BUTTON);
            this.groupBox10.Controls.Add(this.Multiple_compression_set_button);
            this.groupBox10.Controls.Add(this.time_num_input_text);
            this.groupBox10.Controls.Add(this.Waiting_time_text);
            this.groupBox10.Controls.Add(this.time_num_input);
            this.groupBox10.Controls.Add(this.WAITING_TIME_INDICATOR);
            this.groupBox10.Location = new System.Drawing.Point(601, 392);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(291, 195);
            this.groupBox10.TabIndex = 55;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Multiple compression";
            this.groupBox10.Enter += new System.EventHandler(this.groupBox10_Enter);
            // 
            // thickness2_text
            // 
            this.thickness2_text.AutoSize = true;
            this.thickness2_text.Location = new System.Drawing.Point(166, 112);
            this.thickness2_text.Name = "thickness2_text";
            this.thickness2_text.Size = new System.Drawing.Size(118, 12);
            this.thickness2_text.TabIndex = 55;
            this.thickness2_text.Text = "Thickness(0.01mm)";
            // 
            // thickness2_input
            // 
            this.thickness2_input.Location = new System.Drawing.Point(164, 130);
            this.thickness2_input.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.thickness2_input.Name = "thickness2_input";
            this.thickness2_input.Size = new System.Drawing.Size(101, 21);
            this.thickness2_input.TabIndex = 54;
            // 
            // thickness1_text
            // 
            this.thickness1_text.AutoSize = true;
            this.thickness1_text.Location = new System.Drawing.Point(10, 112);
            this.thickness1_text.Name = "thickness1_text";
            this.thickness1_text.Size = new System.Drawing.Size(149, 12);
            this.thickness1_text.TabIndex = 53;
            this.thickness1_text.Text = "Thickness＿10g(0.01mm)";
            this.thickness1_text.Click += new System.EventHandler(this.thickness_text_Click);
            // 
            // thickness1_input
            // 
            this.thickness1_input.Location = new System.Drawing.Point(8, 130);
            this.thickness1_input.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.thickness1_input.Name = "thickness1_input";
            this.thickness1_input.Size = new System.Drawing.Size(101, 21);
            this.thickness1_input.TabIndex = 52;
            // 
            // Strain_text
            // 
            this.Strain_text.AutoSize = true;
            this.Strain_text.Location = new System.Drawing.Point(164, 67);
            this.Strain_text.Name = "Strain_text";
            this.Strain_text.Size = new System.Drawing.Size(37, 12);
            this.Strain_text.TabIndex = 51;
            this.Strain_text.Text = "Strain";
            // 
            // strain_indicator
            // 
            this.strain_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.strain_indicator.Location = new System.Drawing.Point(164, 83);
            this.strain_indicator.Name = "strain_indicator";
            this.strain_indicator.Size = new System.Drawing.Size(101, 21);
            this.strain_indicator.TabIndex = 50;
            this.strain_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.strain_indicator.Click += new System.EventHandler(this.label6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 49;
            this.label1.Text = "pressure";
            // 
            // Multiple_compression_pressure
            // 
            this.Multiple_compression_pressure.Location = new System.Drawing.Point(8, 85);
            this.Multiple_compression_pressure.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Multiple_compression_pressure.Name = "Multiple_compression_pressure";
            this.Multiple_compression_pressure.Size = new System.Drawing.Size(101, 21);
            this.Multiple_compression_pressure.TabIndex = 48;
            this.Multiple_compression_pressure.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Multiple_compression_set_button
            // 
            this.Multiple_compression_set_button.Location = new System.Drawing.Point(12, 163);
            this.Multiple_compression_set_button.Name = "Multiple_compression_set_button";
            this.Multiple_compression_set_button.Size = new System.Drawing.Size(75, 23);
            this.Multiple_compression_set_button.TabIndex = 47;
            this.Multiple_compression_set_button.Text = "set";
            this.Multiple_compression_set_button.UseVisualStyleBackColor = true;
            this.Multiple_compression_set_button.Click += new System.EventHandler(this.Multiple_compression_set_button_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.groupBox12);
            this.groupBox11.Controls.Add(this.groupBox13);
            this.groupBox11.Location = new System.Drawing.Point(12, 392);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(316, 205);
            this.groupBox11.TabIndex = 56;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Calibration";
            this.groupBox11.Enter += new System.EventHandler(this.groupBox11_Enter);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.gap_distance_start_button);
            this.groupBox12.Controls.Add(this.gap_distance_ready_button);
            this.groupBox12.Controls.Add(this.end_position_text);
            this.groupBox12.Controls.Add(this.Start_Position_indicator);
            this.groupBox12.Controls.Add(this.start_position_text);
            this.groupBox12.Controls.Add(this.End_Position_indicator);
            this.groupBox12.Location = new System.Drawing.Point(3, 20);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(176, 175);
            this.groupBox12.TabIndex = 63;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "distance";
            this.groupBox12.Enter += new System.EventHandler(this.groupBox12_Enter_1);
            // 
            // gap_distance_start_button
            // 
            this.gap_distance_start_button.Location = new System.Drawing.Point(3, 108);
            this.gap_distance_start_button.Name = "gap_distance_start_button";
            this.gap_distance_start_button.Size = new System.Drawing.Size(53, 35);
            this.gap_distance_start_button.TabIndex = 60;
            this.gap_distance_start_button.Text = "start";
            this.gap_distance_start_button.UseVisualStyleBackColor = true;
            this.gap_distance_start_button.Click += new System.EventHandler(this.gap_distance_start_button_Click);
            // 
            // end_position_text
            // 
            this.end_position_text.AutoSize = true;
            this.end_position_text.Location = new System.Drawing.Point(68, 103);
            this.end_position_text.Name = "end_position_text";
            this.end_position_text.Size = new System.Drawing.Size(74, 12);
            this.end_position_text.TabIndex = 59;
            this.end_position_text.Text = "end position";
            // 
            // Start_Position_indicator
            // 
            this.Start_Position_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Start_Position_indicator.Location = new System.Drawing.Point(70, 41);
            this.Start_Position_indicator.Name = "Start_Position_indicator";
            this.Start_Position_indicator.Size = new System.Drawing.Size(101, 37);
            this.Start_Position_indicator.TabIndex = 57;
            this.Start_Position_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Start_Position_indicator.Click += new System.EventHandler(this.Start_Position_indicator_Click);
            // 
            // start_position_text
            // 
            this.start_position_text.AutoSize = true;
            this.start_position_text.Location = new System.Drawing.Point(68, 20);
            this.start_position_text.Name = "start_position_text";
            this.start_position_text.Size = new System.Drawing.Size(77, 12);
            this.start_position_text.TabIndex = 57;
            this.start_position_text.Text = "start position";
            // 
            // End_Position_indicator
            // 
            this.End_Position_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.End_Position_indicator.Location = new System.Drawing.Point(67, 117);
            this.End_Position_indicator.Name = "End_Position_indicator";
            this.End_Position_indicator.Size = new System.Drawing.Size(101, 37);
            this.End_Position_indicator.TabIndex = 58;
            this.End_Position_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.End_Position_indicator.Click += new System.EventHandler(this.End_Position_indicator_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.pressure_cal_button);
            this.groupBox13.Controls.Add(this.label2);
            this.groupBox13.Controls.Add(this.pressure_cal_start_position);
            this.groupBox13.Controls.Add(this.pressure_cal_velocity);
            this.groupBox13.Controls.Add(this.label4);
            this.groupBox13.Location = new System.Drawing.Point(185, 20);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(124, 175);
            this.groupBox13.TabIndex = 61;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "pressure";
            // 
            // pressure_cal_button
            // 
            this.pressure_cal_button.Location = new System.Drawing.Point(6, 21);
            this.pressure_cal_button.Name = "pressure_cal_button";
            this.pressure_cal_button.Size = new System.Drawing.Size(100, 35);
            this.pressure_cal_button.TabIndex = 28;
            this.pressure_cal_button.Text = "pressure cal";
            this.pressure_cal_button.UseVisualStyleBackColor = true;
            this.pressure_cal_button.Click += new System.EventHandler(this.pressure_cal_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 61;
            this.label2.Text = "start position";
            // 
            // pressure_cal_start_position
            // 
            this.pressure_cal_start_position.Location = new System.Drawing.Point(6, 122);
            this.pressure_cal_start_position.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.pressure_cal_start_position.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.pressure_cal_start_position.Name = "pressure_cal_start_position";
            this.pressure_cal_start_position.Size = new System.Drawing.Size(101, 21);
            this.pressure_cal_start_position.TabIndex = 60;
            // 
            // pressure_cal_velocity
            // 
            this.pressure_cal_velocity.Location = new System.Drawing.Point(6, 74);
            this.pressure_cal_velocity.Maximum = new decimal(new int[] {
            2047,
            0,
            0,
            0});
            this.pressure_cal_velocity.Minimum = new decimal(new int[] {
            2047,
            0,
            0,
            -2147483648});
            this.pressure_cal_velocity.Name = "pressure_cal_velocity";
            this.pressure_cal_velocity.Size = new System.Drawing.Size(101, 21);
            this.pressure_cal_velocity.TabIndex = 59;
            this.pressure_cal_velocity.ValueChanged += new System.EventHandler(this.pressure_cal_velocity_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 12);
            this.label4.TabIndex = 62;
            this.label4.Text = "rpm_setting";
            // 
            // TIMER3
            // 
            this.TIMER3.Enabled = true;
            this.TIMER3.Interval = 99;
            this.TIMER3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.AI_set_button);
            this.groupBox14.Controls.Add(this.predict_thickness_input);
            this.groupBox14.Controls.Add(this.label8);
            this.groupBox14.Controls.Add(this.predict_class_input);
            this.groupBox14.Controls.Add(this.label6);
            this.groupBox14.Controls.Add(this.button2);
            this.groupBox14.Controls.Add(this.stop_pressure_text);
            this.groupBox14.Controls.Add(this.label7);
            this.groupBox14.Controls.Add(this.state_indicator);
            this.groupBox14.Controls.Add(this.state_text);
            this.groupBox14.Controls.Add(this.state_analysis_button);
            this.groupBox14.Location = new System.Drawing.Point(334, 392);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(261, 195);
            this.groupBox14.TabIndex = 57;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "A.I";
            // 
            // predict_thickness_input
            // 
            this.predict_thickness_input.Location = new System.Drawing.Point(138, 89);
            this.predict_thickness_input.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.predict_thickness_input.Name = "predict_thickness_input";
            this.predict_thickness_input.Size = new System.Drawing.Size(101, 21);
            this.predict_thickness_input.TabIndex = 60;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(146, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 61;
            this.label8.Text = "predict thickness";
            // 
            // predict_class_input
            // 
            this.predict_class_input.Location = new System.Drawing.Point(138, 130);
            this.predict_class_input.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.predict_class_input.Name = "predict_class_input";
            this.predict_class_input.Size = new System.Drawing.Size(101, 21);
            this.predict_class_input.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 12);
            this.label6.TabIndex = 58;
            this.label6.Text = "predict class";
            this.label6.Click += new System.EventHandler(this.label6_Click_2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(139, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 35);
            this.button2.TabIndex = 57;
            this.button2.Text = "test_function";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // stop_pressure_text
            // 
            this.stop_pressure_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stop_pressure_text.Location = new System.Drawing.Point(8, 135);
            this.stop_pressure_text.Name = "stop_pressure_text";
            this.stop_pressure_text.Size = new System.Drawing.Size(101, 21);
            this.stop_pressure_text.TabIndex = 55;
            this.stop_pressure_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stop_pressure_text.Click += new System.EventHandler(this.stop_pressure_text_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 12);
            this.label7.TabIndex = 56;
            this.label7.Text = "pressure";
            // 
            // state_indicator
            // 
            this.state_indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.state_indicator.Location = new System.Drawing.Point(8, 83);
            this.state_indicator.Name = "state_indicator";
            this.state_indicator.Size = new System.Drawing.Size(101, 21);
            this.state_indicator.TabIndex = 54;
            this.state_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // state_text
            // 
            this.state_text.AutoSize = true;
            this.state_text.Location = new System.Drawing.Point(6, 61);
            this.state_text.Name = "state_text";
            this.state_text.Size = new System.Drawing.Size(32, 12);
            this.state_text.TabIndex = 54;
            this.state_text.Text = "state";
            // 
            // state_analysis_button
            // 
            this.state_analysis_button.Location = new System.Drawing.Point(6, 20);
            this.state_analysis_button.Name = "state_analysis_button";
            this.state_analysis_button.Size = new System.Drawing.Size(100, 35);
            this.state_analysis_button.TabIndex = 54;
            this.state_analysis_button.Text = "state analysis";
            this.state_analysis_button.UseVisualStyleBackColor = true;
            this.state_analysis_button.Click += new System.EventHandler(this.state_analysis_button_Click);
            // 
            // AI_set_button
            // 
            this.AI_set_button.Location = new System.Drawing.Point(149, 163);
            this.AI_set_button.Name = "AI_set_button";
            this.AI_set_button.Size = new System.Drawing.Size(75, 23);
            this.AI_set_button.TabIndex = 62;
            this.AI_set_button.Text = "set";
            this.AI_set_button.UseVisualStyleBackColor = true;
            this.AI_set_button.Click += new System.EventHandler(this.AI_set_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 609);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.SAVE_DATA_BUTTON);
            this.Controls.Add(this.GRAPH_STOP_RESUME_BUTTON);
            this.Controls.Add(this.GRAPH_RESET_BUTTON);
            this.Controls.Add(this.Raw_current_indicatior);
            this.Controls.Add(this.RAW_CURRENT_TEXT);
            this.Controls.Add(this.Chart1);
            this.Controls.Add(this.CHANGE_DIRECTION_BUTTON);
            this.Controls.Add(this.Raw_Position_indicator);
            this.Controls.Add(this.RAW_Position_TEXT);
            this.Controls.Add(this.CONNECTION_BUTTION);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Current_limit_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Velocity_limit_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_num_input)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpm_position_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.target_velocity_input)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.target_current_input)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.target_position_input)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thickness2_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thickness1_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Multiple_compression_pressure)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pressure_cal_start_position)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressure_cal_velocity)).EndInit();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.predict_thickness_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.predict_class_input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CONNECTION_BUTTION;
        private System.Windows.Forms.Button CONTINUE_PRESSURE_BUTTON;
        private System.Windows.Forms.Label RAW_Position_TEXT;
        private System.Windows.Forms.Label Current_TEXT;
        private System.Windows.Forms.Label Velocity_TEXT;
        private System.Windows.Forms.Label RAW_velocity_TEXT;
        private System.Windows.Forms.Label Raw_Position_indicator;
        private System.Windows.Forms.Label Current_indicator;
        private System.Windows.Forms.Label Velocity_indicator;
        private System.Windows.Forms.Label Raw_Velocity_indicator;
        private System.Windows.Forms.Timer TIMER1;
        private System.Windows.Forms.Button CHANGE_DIRECTION_BUTTON;
        private System.Windows.Forms.Label Raw_current_indicatior;
        private System.Windows.Forms.Label RAW_CURRENT_TEXT;
        private System.Windows.Forms.Label Pressure_TEXT;
        private System.Windows.Forms.Label Pressure_indicator;
        private System.Windows.Forms.Button GRAPH_RESET_BUTTON;
        private System.Windows.Forms.Button GRAPH_STOP_RESUME_BUTTON;
        private System.Windows.Forms.Button Current_hold_BUTTON;
        private System.Windows.Forms.Button SAVE_DATA_BUTTON;
        private System.Windows.Forms.Button MULTI_COMPRESSION_BUTTON;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button gap_distance_ready_button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label PRESSURE_LIMIT_INDICATOR;
        private System.Windows.Forms.Label Pressure_limit_text;
        private System.Windows.Forms.Label VELOCITY_LIMIT_INDICATOR;
        private System.Windows.Forms.Label Velocity_limit_text;
        private System.Windows.Forms.Label pressure_limit_input_text;
        private System.Windows.Forms.Label Velocity_limit_input_text;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button PARAMETER_SETTING_BUTTON;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label COM_TEXT;
        private System.Windows.Forms.ComboBox Baudrate_SET_DATA;
        private System.Windows.Forms.Label Baudrate_Text;
        private System.Windows.Forms.Button STOP_BUTTON;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Timer TIMER2;
        private System.Windows.Forms.Label time_num_input_text;
        private System.Windows.Forms.Label WAITING_TIME_INDICATOR;
        private System.Windows.Forms.Label Waiting_time_text;
        private System.Windows.Forms.NumericUpDown Current_limit_input;
        private System.Windows.Forms.NumericUpDown Velocity_limit_input;
        private System.Windows.Forms.NumericUpDown time_num_input;
        private System.Windows.Forms.TextBox COM_SET_DATA;
        public System.Windows.Forms.DataVisualization.Charting.Chart Chart1;
        private System.Windows.Forms.NumericUpDown target_velocity_input;
        private System.Windows.Forms.Label TARGET_VELOCITY_TEXT;
        private System.Windows.Forms.Button Target_velocity_set_button;
        private System.Windows.Forms.Label Time_indicator;
        private System.Windows.Forms.Label TIME_TEXT;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label gap_distance_text;
        private System.Windows.Forms.Label Gap_distance_indicator;
        private System.Windows.Forms.Label Position_text;
        private System.Windows.Forms.Label Position_indicator;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button Target_current_set_button;
        private System.Windows.Forms.NumericUpDown target_current_input;
        private System.Windows.Forms.Label TARGET_CURRENT_TEXT;
        private System.Windows.Forms.Label Target_current_indicator;
        private System.Windows.Forms.Label Target_velocity_indicator;
        private System.Windows.Forms.Button Target_position_set_button;
        private System.Windows.Forms.Label Target_position_indicator;
        private System.Windows.Forms.NumericUpDown target_position_input;
        private System.Windows.Forms.Label TARGET_POSITION_TEXT;
        private System.Windows.Forms.Button Position_button;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button Multiple_compression_set_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Multiple_compression_pressure;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button pressure_cal_button;
        private System.Windows.Forms.Label start_position_text;
        private System.Windows.Forms.Label End_Position_indicator;
        private System.Windows.Forms.Label Start_Position_indicator;
        private System.Windows.Forms.Label end_position_text;
        private System.Windows.Forms.Timer TIMER3;
        private System.Windows.Forms.NumericUpDown pressure_cal_velocity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown pressure_cal_start_position;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button gap_distance_start_button;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label strain_indicator;
        private System.Windows.Forms.Label thickness1_text;
        private System.Windows.Forms.NumericUpDown thickness1_input;
        private System.Windows.Forms.Label Strain_text;
        private System.Windows.Forms.Label rpm_position_text;
        private System.Windows.Forms.NumericUpDown rpm_position_input;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label state_indicator;
        private System.Windows.Forms.Label state_text;
        private System.Windows.Forms.Button state_analysis_button;
        private System.Windows.Forms.Label stop_pressure_text;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label thickness2_text;
        private System.Windows.Forms.NumericUpDown thickness2_input;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown predict_class_input;
        private System.Windows.Forms.NumericUpDown predict_thickness_input;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button AI_set_button;
    }
}

