![](https://i.imgur.com/wTY7bFY.png)

# Locadora de Automóveis — Sistema de Gestão Web

## Visão Geral

Este repositório contém um sistema completo para gestão de locadoras de veículos.  
Inclui módulos de clientes, condutores, automóveis, aluguéis, devoluções, taxas, funcionários e multitenancy.

O projeto é dividido em:

- Backend em .NET
- Frontend em Angular

---

## Tecnologias Utilizadas

### Backend

- .NET 8
- ASP.NET Web API
- Entity Framework Core
- SQL Server
- JWT Authentication

### Frontend

- Angular
- Angular Material / Bootstrap
- TypeScript
- RxJS

---

## Funcionalidades

### Autenticação e Acesso

- Registro de empresa
- Login e Logout
- Controle por perfis (Administrador e Funcionário)
- Proteção de rotas via JWT

---

### Funcionários

- Cadastro, edição e exclusão
- Funcionário só edita seus próprios dados
- Administrador gerencia demais funcionários

---

### Grupos, Planos e Automóveis

#### Grupos de Automóveis

- Cadastro e edição de grupos
- Exemplos: esportivo, utilitário, PCD, caminhonete

#### Planos de Cobrança

- Plano Diário
- Plano Livre
- Plano Controlado
- Configuração de valores, km e excedentes

#### Automóveis

- Cadastro completo com foto
- Vínculo ao grupo
- Edição e exclusão bloqueadas quando há aluguel em aberto
- Listagem com filtros por grupo

#### Configurações

- Definição dos preços de combustível

---

### Clientes e Condutores

- Cadastro de Pessoa Física (PF)
- Cadastro de Pessoa Jurídica (PJ)
- PJ deve possuir um condutor vinculado
- Cadastro de condutores com CNH e validade

---

### Taxas e Serviços

- Cadastro de taxas fixas ou por dia
- Utilização no aluguel

---

### Aluguéis e Devoluções

#### Aluguéis

- Seleção de cliente, condutor e veículo
- Definição do plano de cobrança
- Adição de taxas e serviços
- Seguro adicional
- Caução
- Cálculo automático do valor

#### Devolução

- Registro de quilometragem
- Nível de combustível
- Multa por atraso (10%)
- Cálculo final completo

---

## Multitenancy

O sistema utiliza TenantId para isolar os dados de cada empresa (locadora).

Garantias:

- Cada empresa visualiza apenas seus próprios dados
- Todas as consultas são filtradas automaticamente
- Segurança reforçada por usuário autenticado

---

## Como Executar o Projeto

### Frontend

- cd client
- npm install
- npm start

### Backend

- cd server
- dotnet restore
- dotnet ef database update
- dotnet run

## Estrutura do projeto

### /server

- Controllers/
- Application/
- Domain/
- Infrastructure/
- Migrations/

### /client

- src/
- app/
- components/
- pages/
- services/
