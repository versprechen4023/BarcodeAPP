namespace Reader
{
	partial class Reader
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
			this.gbBarRead = new System.Windows.Forms.GroupBox();
			this.cbCameraList = new System.Windows.Forms.ComboBox();
			this.lbCameraInfo = new System.Windows.Forms.Label();
			this.pbBarcode = new System.Windows.Forms.PictureBox();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.gbBarButton = new System.Windows.Forms.GroupBox();
			this.btnUpload = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnlvExport = new System.Windows.Forms.Button();
			this.btnlvClear = new System.Windows.Forms.Button();
			this.lvProList = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
			this.gbBarRead.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).BeginInit();
			this.gbBarButton.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbBarRead
			// 
			this.gbBarRead.Controls.Add(this.cbCameraList);
			this.gbBarRead.Controls.Add(this.lbCameraInfo);
			this.gbBarRead.Controls.Add(this.pbBarcode);
			this.gbBarRead.Location = new System.Drawing.Point(12, 12);
			this.gbBarRead.Name = "gbBarRead";
			this.gbBarRead.Size = new System.Drawing.Size(393, 426);
			this.gbBarRead.TabIndex = 0;
			this.gbBarRead.TabStop = false;
			this.gbBarRead.Text = "바코드 인식창";
			// 
			// cbCameraList
			// 
			this.cbCameraList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCameraList.FormattingEnabled = true;
			this.cbCameraList.Location = new System.Drawing.Point(114, 21);
			this.cbCameraList.Name = "cbCameraList";
			this.cbCameraList.Size = new System.Drawing.Size(267, 20);
			this.cbCameraList.TabIndex = 2;
			this.cbCameraList.SelectedIndexChanged += new System.EventHandler(this.cbCameraList_SelectedIndexChanged);
			// 
			// lbCameraInfo
			// 
			this.lbCameraInfo.AutoSize = true;
			this.lbCameraInfo.Location = new System.Drawing.Point(6, 24);
			this.lbCameraInfo.Name = "lbCameraInfo";
			this.lbCameraInfo.Size = new System.Drawing.Size(81, 12);
			this.lbCameraInfo.TabIndex = 1;
			this.lbCameraInfo.Text = "사용할 카메라";
			// 
			// pbBarcode
			// 
			this.pbBarcode.BackColor = System.Drawing.SystemColors.Window;
			this.pbBarcode.Location = new System.Drawing.Point(6, 55);
			this.pbBarcode.Name = "pbBarcode";
			this.pbBarcode.Size = new System.Drawing.Size(375, 365);
			this.pbBarcode.TabIndex = 0;
			this.pbBarcode.TabStop = false;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// gbBarButton
			// 
			this.gbBarButton.Controls.Add(this.btnUpload);
			this.gbBarButton.Controls.Add(this.btnStop);
			this.gbBarButton.Controls.Add(this.btnStart);
			this.gbBarButton.Location = new System.Drawing.Point(411, 12);
			this.gbBarButton.Name = "gbBarButton";
			this.gbBarButton.Size = new System.Drawing.Size(256, 163);
			this.gbBarButton.TabIndex = 1;
			this.gbBarButton.TabStop = false;
			this.gbBarButton.Text = "버튼";
			// 
			// btnUpload
			// 
			this.btnUpload.Location = new System.Drawing.Point(6, 110);
			this.btnUpload.Name = "btnUpload";
			this.btnUpload.Size = new System.Drawing.Size(239, 35);
			this.btnUpload.TabIndex = 2;
			this.btnUpload.Text = "이미지로 바코드 인식";
			this.btnUpload.UseVisualStyleBackColor = true;
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			// 
			// btnStop
			// 
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(136, 24);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(109, 80);
			this.btnStop.TabIndex = 1;
			this.btnStop.Text = "바코드 인식 종료";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(6, 24);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(118, 80);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "바코드 인식 시작";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnlvExport);
			this.groupBox3.Controls.Add(this.btnlvClear);
			this.groupBox3.Controls.Add(this.lvProList);
			this.groupBox3.Location = new System.Drawing.Point(417, 181);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(250, 257);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "바코드 내역";
			// 
			// btnlvExport
			// 
			this.btnlvExport.Location = new System.Drawing.Point(130, 224);
			this.btnlvExport.Name = "btnlvExport";
			this.btnlvExport.Size = new System.Drawing.Size(114, 23);
			this.btnlvExport.TabIndex = 2;
			this.btnlvExport.Text = "리스트 내보내기";
			this.btnlvExport.UseVisualStyleBackColor = true;
			this.btnlvExport.Click += new System.EventHandler(this.btnlvExport_Click);
			// 
			// btnlvClear
			// 
			this.btnlvClear.Location = new System.Drawing.Point(6, 224);
			this.btnlvClear.Name = "btnlvClear";
			this.btnlvClear.Size = new System.Drawing.Size(118, 23);
			this.btnlvClear.TabIndex = 1;
			this.btnlvClear.Text = "리스트 초기화";
			this.btnlvClear.UseVisualStyleBackColor = true;
			this.btnlvClear.Click += new System.EventHandler(this.btnlvClear_Click);
			// 
			// lvProList
			// 
			this.lvProList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.lvProList.FullRowSelect = true;
			this.lvProList.GridLines = true;
			this.lvProList.HideSelection = false;
			this.lvProList.Location = new System.Drawing.Point(6, 20);
			this.lvProList.MultiSelect = false;
			this.lvProList.Name = "lvProList";
			this.lvProList.Size = new System.Drawing.Size(238, 198);
			this.lvProList.TabIndex = 0;
			this.lvProList.UseCompatibleStateImageBehavior = false;
			this.lvProList.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "상품 번호";
			this.columnHeader1.Width = 72;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "상품 이름";
			this.columnHeader2.Width = 87;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "상품 가격";
			this.columnHeader3.Width = 74;
			// 
			// Reader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(679, 450);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.gbBarButton);
			this.Controls.Add(this.gbBarRead);
			this.Name = "Reader";
			this.Text = "BarcodeReader";
			this.Load += new System.EventHandler(this.Reader_Load);
			this.gbBarRead.ResumeLayout(false);
			this.gbBarRead.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).EndInit();
			this.gbBarButton.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbBarRead;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.GroupBox gbBarButton;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.PictureBox pbBarcode;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.ComboBox cbCameraList;
		private System.Windows.Forms.Label lbCameraInfo;
		private System.Windows.Forms.Button btnUpload;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnlvExport;
		private System.Windows.Forms.Button btnlvClear;
		private System.Windows.Forms.ListView lvProList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.ComponentModel.BackgroundWorker backgroundWorker2;
	}
}

