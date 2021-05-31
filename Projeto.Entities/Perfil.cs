using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Perfil
    {
        public long PRF_IDENTIFICADOR { get; set; }
        public string PRF_CODIGO { get; set; }
        public string PRF_DESCRICAO { get; set; }
        public Perfil()
        {

        }
        public Perfil(long id, string codigo, string descricao)
        {
            PRF_IDENTIFICADOR = id;
            PRF_CODIGO = codigo;
            PRF_DESCRICAO = descricao;
        }

        public PerfilEnum Tipo
        {
            get
            {
                switch (PRF_CODIGO)
                {
                    case "ADM":
                        return PerfilEnum.ADMINISTRADOR;
                    case "CON":
                        return PerfilEnum.CONSULTOR;
                    default:
                        return PerfilEnum.CONSULTOR;
                }
            }
        }
    }

    public enum PerfilEnum
    {
        ADMINISTRADOR,
        CONSULTOR
    }
}
