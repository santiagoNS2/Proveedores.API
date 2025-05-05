using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Proveedores.Domain.Entities
{
    /// <summary>
    /// Entidad que representa a un proveedor registrado en la base de datos.
    /// </summary>
    public class Proveedor
    {
        /// <summary> Identificador único del proveedor en la base de datos (MongoDB). </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary> Número de Identificación Tributaria. </summary>
        public string Nit { get; set; }

        /// <summary> Razón social del proveedor. </summary>
        public string RazonSocial { get; set; }

        /// <summary> Dirección del proveedor. </summary>
        public string Direccion { get; set; }

        /// <summary> Ciudad donde se ubica el proveedor. </summary>
        public string Ciudad { get; set; }

        /// <summary> Departamento correspondiente a la ubicación del proveedor. </summary>
        public string Departamento { get; set; }

        /// <summary> Correo electrónico del proveedor. </summary>
        public string Correo { get; set; }

        /// <summary> Estado del proveedor (activo o inactivo). </summary>
        public bool Activo { get; set; }

        /// <summary> Fecha en la que se creó el proveedor en el sistema. </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary> Nombre del contacto responsable del proveedor. </summary>
        public string NombreContacto { get; set; }

        /// <summary> Correo del contacto responsable del proveedor. </summary>
        public string CorreoContacto { get; set; }
    }
}
