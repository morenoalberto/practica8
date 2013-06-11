using System;
using Gtk;
using MySql.Data.MySqlClient;
using Practica8;

public partial class MainWindow: Gtk.Window
{	
	private int x;
	private int y;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	public void tabla(){

		this.encabezado();	
		this.cuerpo();
		this.Child.ShowAll();
	}
	private void encabezado(){	
		this.x = 25;
		this.y = 58;
		this.etiqueta("lblID", "<span size=\"14000\" foreground=\"BLUE\" weight=\"bold\">ID</span>");
		this.x += 100;
		this.etiqueta("lblNombre", "<span size=\"14000\" foreground=\"BLUE\" weight=\"bold\">NOMBRE</span>");
		this.x += 200;
		this.etiqueta("lblAnio", "<span size=\"14000\" foreground=\"BLUE\" weight=\"bold\">ANIO</span>");
		this.x += 200;
		this.etiqueta("lblOpciones", "<span size=\"14000\" foreground=\"BLUE\" weight=\"bold\">OPCIONES</span>");
	}
	private void cuerpo(){
		VideojuegosAcciones acciones = new VideojuegosAcciones();
		System.Collections.ArrayList videojuegos = acciones.obtenerTodos();
		foreach(Videojuegos videojuego in videojuegos){
			this.x = 25;
			this.y += 40;
			this.registro(videojuego);
		}
	}
	private void registro(Videojuegos videojuegos){
		this.etiqueta("lblID_" + videojuegos.ID, "<span size=\"12000\" foreground=\"#000000\">" + videojuegos.ID + "</span>");
		this.x += 100;
		this.etiqueta("lblNombre_" + videojuegos.ID, "<span size=\"12000\" foreground=\"#000000\">" + videojuegos.nombre + "</span>");
		this.x += 200;
		this.etiqueta("lblAnio_" + videojuegos.ID, "<span size=\"12000\" foreground=\"#000000\">" + videojuegos.anio + "</span>");
		this.x += 200;
		this.opciones(videojuegos);
	}
	private void opciones(Videojuegos videojuegos){
		this.boton("btnMostar_" + videojuegos.ID, "Mostar", "gtk-edit");
		this.x += 100;

	}
	private void etiqueta(string nombre, string markup){
		Gtk.Label etiqueta = new global::Gtk.Label ();
		etiqueta.Name = nombre;
		etiqueta.Markup = markup;
		etiqueta.UseMarkup = true;
		this.fixed1.Add (etiqueta);
		global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[etiqueta]));
		w11.X = this.x;
		w11.Y = this.y;
	}
	
	private void boton(string nombre, string label, string imagen){
		Gtk.Button boton = new global::Gtk.Button ();
		boton.CanFocus = true;
		boton.Name = nombre;
		boton.UseUnderline = true;
		// Container child btnNuevo.Gtk.Container+ContainerChild
		global::Gtk.Alignment w1 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		global::Gtk.HBox w2 = new global::Gtk.HBox ();
		w2.Spacing = 2;
		// Container child GtkHBox.Gtk.Container+ContainerChild
		global::Gtk.Image w3 = new global::Gtk.Image ();
		//w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, imagen, global::Gtk.IconSize.Button);
		w2.Add (w3);
		// Container child GtkHBox.Gtk.Container+ContainerChild
		global::Gtk.Label w5 = new global::Gtk.Label ();
		w5.LabelProp = global::Mono.Unix.Catalog.GetString (label);
		w5.UseUnderline = true;
		w2.Add (w5);
		w1.Add (w2);
		boton.Add (w1);
		this.fixed1.Add (boton);
		global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[boton]));
		w9.X = this.x;
		w9.Y = this.y - 10;

	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnBtnMostarClicked (object sender, EventArgs e)
	{
		Gtk.Button btnMostrar = (Gtk.Button) sender;
		string id = btnMostrar.Name.Replace("btnMostrar_", "");
		//Nuevo mostrar = new Nuevo(this, id);
		//mostrar.Show();
	}
}
