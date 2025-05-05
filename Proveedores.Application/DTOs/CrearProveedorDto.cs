namespace Proveedores.Application.DTOs
{
    /// <summary>
    /// DTO para crear un nuevo proveedor.
    /// </summary>
    public class CrearProveedorDto
    {
        /// <summary> Número de Identificación Tributaria del proveedor. </summary>
        public string Nit { get; set; }

        /// <summary> Razón social del proveedor. </summary>
        public string RazonSocial { get; set; }

        /// <summary> Dirección física del proveedor. </summary>
        public string Direccion { get; set; }

        /// <summary> Ciudad donde opera el proveedor. </summary>
        public string Ciudad { get; set; }

        /// <summary> Departamento donde opera el proveedor. </summary>
        public string Departamento { get; set; }

        /// <summary> Correo electrónico principal del proveedor. </summary>
        public string Correo { get; set; }

        /// <summary> Indica si el proveedor está activo. </summary>
        public bool Activo { get; set; }

        /// <summary> Fecha de creación del registro del proveedor. </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary> Nombre completo del contacto principal. </summary>
        public string NombreContacto { get; set; }

        /// <summary> Correo del contacto principal del proveedor. </summary>
        public string CorreoContacto { get; set; }
    }
}

