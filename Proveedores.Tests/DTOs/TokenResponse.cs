using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proveedores.Tests
{
    /// <summary>
    /// Representa la respuesta del endpoint de autenticación que devuelve un token JWT.
    /// </summary>
    public class TokenResponse
    {
        public string Token { get; set; }
    }
}


