namespace Interfaces_ptc
{
    partial class frmmenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelVentasubMenu = new System.Windows.Forms.Panel();
            this.btnDetallePedido = new System.Windows.Forms.Button();
            this.btnAdministrarPedido = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelProductossubMenu = new System.Windows.Forms.Panel();
            this.btnAgregarProductos = new System.Windows.Forms.Button();
            this.btnAdministrarProductos = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.btnProducto = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnClienteJuridico = new System.Windows.Forms.Button();
            this.btnClienteNatural = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelVentasubMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            this.panelProductossubMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(0)))), ((int)(((byte)(90)))));
            this.panel1.Controls.Add(this.btnEmpleado);
            this.panel1.Controls.Add(this.panelProductossubMenu);
            this.panel1.Controls.Add(this.btnProducto);
            this.panel1.Controls.Add(this.btnCerrarSesion);
            this.panel1.Controls.Add(this.btnClienteJuridico);
            this.panel1.Controls.Add(this.btnClienteNatural);
            this.panel1.Controls.Add(this.btnProveedores);
            this.panel1.Controls.Add(this.panelVentasubMenu);
            this.panel1.Controls.Add(this.btnVentas);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 687);
            this.panel1.TabIndex = 0;
            // 
            // panelVentasubMenu
            // 
            this.panelVentasubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(130)))), ((int)(((byte)(173)))));
            this.panelVentasubMenu.Controls.Add(this.btnDetallePedido);
            this.panelVentasubMenu.Controls.Add(this.btnAdministrarPedido);
            this.panelVentasubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelVentasubMenu.Location = new System.Drawing.Point(0, 101);
            this.panelVentasubMenu.Name = "panelVentasubMenu";
            this.panelVentasubMenu.Size = new System.Drawing.Size(250, 74);
            this.panelVentasubMenu.TabIndex = 1;
            // 
            // btnDetallePedido
            // 
            this.btnDetallePedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDetallePedido.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDetallePedido.FlatAppearance.BorderSize = 0;
            this.btnDetallePedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetallePedido.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetallePedido.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDetallePedido.Location = new System.Drawing.Point(0, 34);
            this.btnDetallePedido.Name = "btnDetallePedido";
            this.btnDetallePedido.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnDetallePedido.Size = new System.Drawing.Size(250, 40);
            this.btnDetallePedido.TabIndex = 2;
            this.btnDetallePedido.Text = "Detalle Pedido";
            this.btnDetallePedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetallePedido.UseVisualStyleBackColor = true;
            this.btnDetallePedido.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // btnAdministrarPedido
            // 
            this.btnAdministrarPedido.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdministrarPedido.FlatAppearance.BorderSize = 0;
            this.btnAdministrarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrarPedido.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrarPedido.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdministrarPedido.Location = new System.Drawing.Point(0, 0);
            this.btnAdministrarPedido.Name = "btnAdministrarPedido";
            this.btnAdministrarPedido.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnAdministrarPedido.Size = new System.Drawing.Size(250, 34);
            this.btnAdministrarPedido.TabIndex = 1;
            this.btnAdministrarPedido.Text = "Administrar Pedido";
            this.btnAdministrarPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministrarPedido.UseVisualStyleBackColor = true;
            this.btnAdministrarPedido.Click += new System.EventHandler(this.btnDetallePedido_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 55);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido a StockGenius";
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(124)))));
            this.panelContenedor.Controls.Add(this.pbLogo);
            this.panelContenedor.Controls.Add(this.pictureBox5);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(250, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(934, 687);
            this.panelContenedor.TabIndex = 4;
            // 
            // panelProductossubMenu
            // 
            this.panelProductossubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(130)))), ((int)(((byte)(173)))));
            this.panelProductossubMenu.Controls.Add(this.btnAgregarProductos);
            this.panelProductossubMenu.Controls.Add(this.btnAdministrarProductos);
            this.panelProductossubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProductossubMenu.Location = new System.Drawing.Point(0, 393);
            this.panelProductossubMenu.Name = "panelProductossubMenu";
            this.panelProductossubMenu.Size = new System.Drawing.Size(250, 74);
            this.panelProductossubMenu.TabIndex = 12;
            // 
            // btnAgregarProductos
            // 
            this.btnAgregarProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregarProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAgregarProductos.FlatAppearance.BorderSize = 0;
            this.btnAgregarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProductos.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProductos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregarProductos.Location = new System.Drawing.Point(0, 34);
            this.btnAgregarProductos.Name = "btnAgregarProductos";
            this.btnAgregarProductos.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnAgregarProductos.Size = new System.Drawing.Size(250, 40);
            this.btnAgregarProductos.TabIndex = 2;
            this.btnAgregarProductos.Text = "Ingresar Productos";
            this.btnAgregarProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarProductos.UseVisualStyleBackColor = true;
            this.btnAgregarProductos.Click += new System.EventHandler(this.btnAgregarProductos_Click);
            // 
            // btnAdministrarProductos
            // 
            this.btnAdministrarProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdministrarProductos.FlatAppearance.BorderSize = 0;
            this.btnAdministrarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrarProductos.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrarProductos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdministrarProductos.Location = new System.Drawing.Point(0, 0);
            this.btnAdministrarProductos.Name = "btnAdministrarProductos";
            this.btnAdministrarProductos.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnAdministrarProductos.Size = new System.Drawing.Size(250, 34);
            this.btnAdministrarProductos.TabIndex = 1;
            this.btnAdministrarProductos.Text = "Administrar Productos";
            this.btnAdministrarProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministrarProductos.UseVisualStyleBackColor = true;
            this.btnAdministrarProductos.Click += new System.EventHandler(this.btnAdministrarProductos_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(934, 687);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(6, 297);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(46, 39);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(0)))), ((int)(((byte)(90)))));
            this.btnEmpleado.BackgroundImage = global::Interfaces_ptc.Properties.Resources.Empleado;
            this.btnEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEmpleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmpleado.FlatAppearance.BorderSize = 0;
            this.btnEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleado.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleado.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmpleado.Location = new System.Drawing.Point(0, 467);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnEmpleado.Size = new System.Drawing.Size(250, 45);
            this.btnEmpleado.TabIndex = 13;
            this.btnEmpleado.Text = "Empleados";
            this.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleado.UseVisualStyleBackColor = false;
            this.btnEmpleado.Click += new System.EventHandler(this.btnEmpleado_Click_2);
            // 
            // btnProducto
            // 
            this.btnProducto.BackgroundImage = global::Interfaces_ptc.Properties.Resources.Producto;
            this.btnProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducto.FlatAppearance.BorderSize = 0;
            this.btnProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducto.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProducto.Location = new System.Drawing.Point(0, 343);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProducto.Size = new System.Drawing.Size(250, 50);
            this.btnProducto.TabIndex = 11;
            this.btnProducto.Text = "Productos";
            this.btnProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducto.UseVisualStyleBackColor = true;
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click_1);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackgroundImage = global::Interfaces_ptc.Properties.Resources.Salir1;
            this.btnCerrarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Cambria", 11F);
            this.btnCerrarSesion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 635);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCerrarSesion.Size = new System.Drawing.Size(250, 52);
            this.btnCerrarSesion.TabIndex = 9;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnClienteJuridico
            // 
            this.btnClienteJuridico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(0)))), ((int)(((byte)(90)))));
            this.btnClienteJuridico.BackgroundImage = global::Interfaces_ptc.Properties.Resources.Clientejuridico;
            this.btnClienteJuridico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClienteJuridico.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClienteJuridico.FlatAppearance.BorderSize = 0;
            this.btnClienteJuridico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClienteJuridico.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClienteJuridico.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClienteJuridico.Location = new System.Drawing.Point(0, 286);
            this.btnClienteJuridico.Name = "btnClienteJuridico";
            this.btnClienteJuridico.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnClienteJuridico.Size = new System.Drawing.Size(250, 57);
            this.btnClienteJuridico.TabIndex = 7;
            this.btnClienteJuridico.Text = "Clientes Jurídicos";
            this.btnClienteJuridico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClienteJuridico.UseVisualStyleBackColor = false;
            this.btnClienteJuridico.Click += new System.EventHandler(this.btnAdministrarEmpleados_Click);
            // 
            // btnClienteNatural
            // 
            this.btnClienteNatural.BackgroundImage = global::Interfaces_ptc.Properties.Resources.ClientesNaturales;
            this.btnClienteNatural.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClienteNatural.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClienteNatural.FlatAppearance.BorderSize = 0;
            this.btnClienteNatural.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClienteNatural.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClienteNatural.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClienteNatural.Location = new System.Drawing.Point(0, 232);
            this.btnClienteNatural.Name = "btnClienteNatural";
            this.btnClienteNatural.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnClienteNatural.Size = new System.Drawing.Size(250, 54);
            this.btnClienteNatural.TabIndex = 6;
            this.btnClienteNatural.Text = "Clientes Naturales";
            this.btnClienteNatural.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClienteNatural.UseVisualStyleBackColor = true;
            this.btnClienteNatural.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackgroundImage = global::Interfaces_ptc.Properties.Resources.proveedorr;
            this.btnProveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProveedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProveedores.Location = new System.Drawing.Point(0, 175);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProveedores.Size = new System.Drawing.Size(250, 57);
            this.btnProveedores.TabIndex = 4;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.UseVisualStyleBackColor = true;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedor_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackgroundImage = global::Interfaces_ptc.Properties.Resources.Ventas1;
            this.btnVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentas.Location = new System.Drawing.Point(0, 55);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVentas.Size = new System.Drawing.Size(250, 46);
            this.btnVentas.TabIndex = 1;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnPedidos_Click);
            // 
            // frmmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 687);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 726);
            this.MinimumSize = new System.Drawing.Size(1200, 726);
            this.Name = "frmmenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmmenu_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmmenu_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panelVentasubMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelContenedor.ResumeLayout(false);
            this.panelProductossubMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Panel panelVentasubMenu;
        private System.Windows.Forms.Button btnDetallePedido;
        private System.Windows.Forms.Button btnAdministrarPedido;
        private System.Windows.Forms.Button btnClienteNatural;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnClienteJuridico;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelProductossubMenu;
        private System.Windows.Forms.Button btnAgregarProductos;
        private System.Windows.Forms.Button btnAdministrarProductos;
        private System.Windows.Forms.Button btnProducto;
        private System.Windows.Forms.Button btnEmpleado;
    }
}