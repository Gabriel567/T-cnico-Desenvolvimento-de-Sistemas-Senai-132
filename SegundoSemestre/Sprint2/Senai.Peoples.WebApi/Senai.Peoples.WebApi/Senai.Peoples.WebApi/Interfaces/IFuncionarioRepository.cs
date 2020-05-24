using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        //Cadastra um novo funcionário
        void Cadastro(FuncionarioDomain Funcionario); //Objeto Funcionario com os atributos de FuncionarioDomain

        List<FuncionarioDomain> Listar();

        void Deletar(int ID);

        FuncionarioDomain BuscaPorID(int ID);
    }
}
