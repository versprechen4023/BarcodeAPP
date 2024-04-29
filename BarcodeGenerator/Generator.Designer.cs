namespace Generator
{
	partial class Generator
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
			this.gbSQL = new System.Windows.Forms.GroupBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.textProPrice = new System.Windows.Forms.TextBox();
			this.textProName = new System.Windows.Forms.TextBox();
			this.btnCreate = new System.Windows.Forms.Button();
			this.lbProPrice = new System.Windows.Forms.Label();
			this.lbProName = new System.Windows.Forms.Label();
			this.gbBarcode = new System.Windows.Forms.GroupBox();
			this.pbBarcode = new System.Windows.Forms.PictureBox();
			this.btnSaveBarcode = new System.Windows.Forms.Button();
			this.lvProList = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.gbProList = new System.Windows.Forms.GroupBox();
			this.gbSQL.SuspendLayout();
			this.gbBarcode.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).BeginInit();
			this.gbProList.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbSQL
			// 
			this.gbSQL.Controls.Add(this.btnDelete);
			this.gbSQL.Controls.Add(this.btnUpdate);
			this.gbSQL.Controls.Add(this.textProPrice);
			this.gbSQL.Controls.Add(this.textProName);
			this.gbSQL.Controls.Add(this.btnCreate);
			this.gbSQL.Controls.Add(this.lbProPrice);
			this.gbSQL.Controls.Add(this.lbProName);
			this.gbSQL.Location = new System.Drawing.Point(12, 12);
			this.gbSQL.Name = "gbSQL";
			this.gbSQL.Size = new System.Drawing.Size(283, 190);
			this.gbSQL.TabIndex = 1;
			this.gbSQL.TabStop = false;
			this.gbSQL.Text = "명령창";
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(189, 113);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(88, 55);
			this.btnDelete.TabIndex = 6;
			this.btnDelete.Text = "상품 삭제";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(96, 113);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(87, 55);
			this.btnUpdate.TabIndex = 5;
			this.btnUpdate.Text = "상품 수정";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// textProPrice
			// 
			this.textProPrice.Location = new System.Drawing.Point(81, 64);
			this.textProPrice.Name = "textProPrice";
			this.textProPrice.Size = new System.Drawing.Size(177, 21);
			this.textProPrice.TabIndex = 4;
			// 
			// textProName
			// 
			this.textProName.Location = new System.Drawing.Point(81, 37);
			this.textProName.Name = "textProName";
			this.textProName.Size = new System.Drawing.Size(177, 21);
			this.textProName.TabIndex = 3;
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(6, 113);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(84, 55);
			this.btnCreate.TabIndex = 2;
			this.btnCreate.Text = "상품 등록";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// lbProPrice
			// 
			this.lbProPrice.AutoSize = true;
			this.lbProPrice.Location = new System.Drawing.Point(17, 67);
			this.lbProPrice.Name = "lbProPrice";
			this.lbProPrice.Size = new System.Drawing.Size(29, 12);
			this.lbProPrice.TabIndex = 1;
			this.lbProPrice.Text = "가격";
			// 
			// lbProName
			// 
			this.lbProName.AutoSize = true;
			this.lbProName.Location = new System.Drawing.Point(17, 40);
			this.lbProName.Name = "lbProName";
			this.lbProName.Size = new System.Drawing.Size(41, 12);
			this.lbProName.TabIndex = 0;
			this.lbProName.Text = "상품명";
			// 
			// gbBarcode
			// 
			this.gbBarcode.Controls.Add(this.pbBarcode);
			this.gbBarcode.Controls.Add(this.btnSaveBarcode);
			this.gbBarcode.Location = new System.Drawing.Point(301, 12);
			this.gbBarcode.Name = "gbBarcode";
			this.gbBarcode.Size = new System.Drawing.Size(240, 190);
			this.gbBarcode.TabIndex = 2;
			this.gbBarcode.TabStop = false;
			this.gbBarcode.Text = "상품 바코드";
			// 
			// pbBarcode
			// 
			this.pbBarcode.BackColor = System.Drawing.SystemColors.Window;
			this.pbBarcode.Location = new System.Drawing.Point(15, 20);
			this.pbBarcode.Name = "pbBarcode";
			this.pbBarcode.Size = new System.Drawing.Size(219, 125);
			this.pbBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbBarcode.TabIndex = 1;
			this.pbBarcode.TabStop = false;
			// 
			// btnSaveBarcode
			// 
			this.btnSaveBarcode.Location = new System.Drawing.Point(70, 151);
			this.btnSaveBarcode.Name = "btnSaveBarcode";
			this.btnSaveBarcode.Size = new System.Drawing.Size(109, 33);
			this.btnSaveBarcode.TabIndex = 0;
			this.btnSaveBarcode.Text = "바코드 저장";
			this.btnSaveBarcode.UseVisualStyleBackColor = true;
			this.btnSaveBarcode.Click += new System.EventHandler(this.btnSaveBarcode_Click);
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
			this.lvProList.Location = new System.Drawing.Point(3, 21);
			this.lvProList.MultiSelect = false;
			this.lvProList.Name = "lvProList";
			this.lvProList.Size = new System.Drawing.Size(520, 203);
			this.lvProList.TabIndex = 0;
			this.lvProList.UseCompatibleStateImageBehavior = false;
			this.lvProList.View = System.Windows.Forms.View.Details;
			this.lvProList.SelectedIndexChanged += new System.EventHandler(this.lvProList_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "상품 코드";
			this.columnHeader1.Width = 117;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "상품 이름";
			this.columnHeader2.Width = 289;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "상품 가격";
			this.columnHeader3.Width = 110;
			// 
			// gbProList
			// 
			this.gbProList.Controls.Add(this.lvProList);
			this.gbProList.Location = new System.Drawing.Point(12, 208);
			this.gbProList.Name = "gbProList";
			this.gbProList.Size = new System.Drawing.Size(530, 230);
			this.gbProList.TabIndex = 0;
			this.gbProList.TabStop = false;
			this.gbProList.Text = "상품 목록";
			// 
			// Generator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(553, 450);
			this.Controls.Add(this.gbBarcode);
			this.Controls.Add(this.gbSQL);
			this.Controls.Add(this.gbProList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Generator";
			this.Text = "BarcodeGenerator";
			this.Load += new System.EventHandler(this.Generator_Load);
			this.gbSQL.ResumeLayout(false);
			this.gbSQL.PerformLayout();
			this.gbBarcode.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).EndInit();
			this.gbProList.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox gbSQL;
		private System.Windows.Forms.Label lbProPrice;
		private System.Windows.Forms.Label lbProName;
		private System.Windows.Forms.TextBox textProPrice;
		private System.Windows.Forms.TextBox textProName;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.GroupBox gbBarcode;
		private System.Windows.Forms.PictureBox pbBarcode;
		private System.Windows.Forms.Button btnSaveBarcode;
		private System.Windows.Forms.ListView lvProList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.GroupBox gbProList;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnUpdate;
	}
}

