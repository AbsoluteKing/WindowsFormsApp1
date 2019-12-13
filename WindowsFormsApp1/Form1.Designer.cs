namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Top = new System.Windows.Forms.Button();
            this.Jungle = new System.Windows.Forms.Button();
            this.Middle = new System.Windows.Forms.Button();
            this.Bottom = new System.Windows.Forms.Button();
            this.Support = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Top
            // 
            this.Top.Location = new System.Drawing.Point(13, 13);
            this.Top.Name = "Top";
            this.Top.Size = new System.Drawing.Size(63, 65);
            this.Top.TabIndex = 0;
            this.Top.Text = "Top";
            this.Top.UseVisualStyleBackColor = true;
            this.Top.Click += new System.EventHandler(this.Top_Click);
            // 
            // Jungle
            // 
            this.Jungle.Location = new System.Drawing.Point(13, 98);
            this.Jungle.Name = "Jungle";
            this.Jungle.Size = new System.Drawing.Size(63, 65);
            this.Jungle.TabIndex = 1;
            this.Jungle.Text = "Jungle";
            this.Jungle.UseVisualStyleBackColor = true;
            // 
            // Middle
            // 
            this.Middle.Location = new System.Drawing.Point(13, 185);
            this.Middle.Name = "Middle";
            this.Middle.Size = new System.Drawing.Size(63, 65);
            this.Middle.TabIndex = 2;
            this.Middle.Text = "Middle";
            this.Middle.UseCompatibleTextRendering = true;
            this.Middle.UseVisualStyleBackColor = true;
            // 
            // Bottom
            // 
            this.Bottom.Location = new System.Drawing.Point(13, 275);
            this.Bottom.Name = "Bottom";
            this.Bottom.Size = new System.Drawing.Size(63, 65);
            this.Bottom.TabIndex = 3;
            this.Bottom.Text = "Bottom";
            this.Bottom.UseVisualStyleBackColor = true;
            // 
            // Support
            // 
            this.Support.Location = new System.Drawing.Point(13, 363);
            this.Support.Name = "Support";
            this.Support.Size = new System.Drawing.Size(63, 65);
            this.Support.TabIndex = 4;
            this.Support.Text = "Support";
            this.Support.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(104, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 65);
            this.label1.TabIndex = 5;
            this.label1.Text = "READY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(104, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 65);
            this.label2.TabIndex = 6;
            this.label2.Text = "READY";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(104, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 65);
            this.label3.TabIndex = 7;
            this.label3.Text = "READY";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(104, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 65);
            this.label4.TabIndex = 8;
            this.label4.Text = "READY";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(104, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 65);
            this.label5.TabIndex = 9;
            this.label5.Text = "READY";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 444);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Support);
            this.Controls.Add(this.Bottom);
            this.Controls.Add(this.Middle);
            this.Controls.Add(this.Jungle);
            this.Controls.Add(this.Top);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Top;
        private System.Windows.Forms.Button Jungle;
        private System.Windows.Forms.Button Middle;
        private System.Windows.Forms.Button Bottom;
        private System.Windows.Forms.Button Support;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

