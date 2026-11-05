using System.Drawing;
using System.Windows.Forms;

namespace ALBERGUE_HUELLITAS_FELICES;

internal static class SelectorFecha
{
    public static DateTimePicker Crear()
    {
        var fecha = new DateTimePicker
        {
            Format = DateTimePickerFormat.Custom,
            CustomFormat = " ",
            ShowCheckBox = true,
            Checked = false,
            Width = 150,
            Height = 32
        };

        Configurar(fecha);
        return fecha;
    }

    public static void Configurar(DateTimePicker fecha)
    {
        fecha.Format = DateTimePickerFormat.Custom;
        fecha.ValueChanged += (_, _) => ActualizarFormato(fecha);
        fecha.MouseUp += (_, _) => ActualizarFormato(fecha);
        fecha.KeyUp += (_, _) => ActualizarFormato(fecha);
        Vaciar(fecha);
    }

    public static Label CrearEtiqueta(string texto, Point ubicacion) => new()
    {
        Text = texto,
        AutoSize = true,
        Location = ubicacion,
        BackColor = Color.Transparent,
        Font = new Font("Segoe UI", 9F, FontStyle.Bold)
    };

    public static void Vaciar(DateTimePicker fecha)
    {
        fecha.Format = DateTimePickerFormat.Custom;
        fecha.Checked = false;
        fecha.CustomFormat = " ";
    }

    private static void ActualizarFormato(DateTimePicker fecha)
    {
        fecha.CustomFormat = fecha.Checked ? "dd/MM/yyyy" : " ";
    }
}
