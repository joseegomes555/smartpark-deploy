# Trabalho Prático II  
## Integração de Sistemas de Informação

**Licenciatura em Engenharia de Sistemas Informáticos (regime laboral)**  
**Ano letivo:** 2025–2026  

---

## 👤 Identificação do Aluno
- **Número:** 26428  
- **Nome:** José Gomes  
- **Email:** a26428@alunos.ipca.pt  

---

## 📌 Tema do Projeto
**SmartPark - Gestão de Estacionamento Inteligente e Monitorização IoT (Campus/Cidade)**

---

## 🧩 Descrição do Problema
A gestão de parques de estacionamento em ambientes urbanos ou académicos apresenta desafios como a monitorização da ocupação em tempo real, a integração com sensores IoT e a disponibilização de informação a diferentes sistemas e aplicações.

Este projeto propõe o desenvolvimento de uma **API de interoperabilidade** que permita gerir parques de estacionamento inteligentes, integrando dados de ocupação de lugares e disponibilizando essa informação através de **serviços web REST e SOAP**, suportando cenários de integração moderna e legada.

---

## 🎯 Objetivos do Projeto
- Consolidar conceitos de **Integração de Sistemas de Informação**  
- Desenvolver serviços web **RESTful** e **SOAP**  
- Implementar operações CRUD sobre um repositório de dados  
- Documentar a API REST com **Swagger / OpenAPI**  
- Explorar ferramentas e frameworks modernas (.NET, EF Core)  
- Testar e validar os serviços desenvolvidos  
- Preparar os serviços para **publicação em cloud (PaaS)**  

---

## 🏗️ Arquitetura da Solução
A solução foi desenvolvida segundo uma arquitetura em camadas:

- **API REST (.NET)**  
  - Endpoints para gestão de parques e lugares de estacionamento  
  - Documentação automática com Swagger  
- **Serviço SOAP (WCF)**  
  - Focado na integração legada e acesso ao Data Layer  
- **Camada de Dados**  
  - Entity Framework Core  
  - Base de dados relacional (PostgreSQL em cloud)  
- **Base de Dados**  
  - Tabelas principais: `ParkingLots`, `Spots`  

---

## 📂 Organização do Repositório

```
.
├── doc/
│   └── doc_26428-relatorio.pdf
│
├── src/
│   ├── SmartPark.ApiRest        # API REST (.NET + Swagger)
│   ├── SmartPark.SoapService    # Serviço SOAP (WCF)
│   ├── SmartPark.Data           # Camada de acesso a dados (EF Core)
│   ├── SmartPark.Contracts      # DTOs e contratos partilhados
│
├── README.md
```

---

## ▶️ Como Executar o Projeto

### Pré-requisitos
- .NET SDK
- Acesso à base de dados PostgreSQL
- Visual Studio 2022 ou superior

### Passos
1. Clonar o repositório  
2. Configurar a connection string  
3. Executar migrações  
4. Iniciar a API REST  
5. Aceder ao Swagger  
6. Executar o serviço SOAP

---

## 🧪 Testes
- Swagger UI (REST)
- WCF Test Client (SOAP)

---

## ☁️ Cloud
Solução preparada para execução em ambiente **PaaS**, com base de dados em cloud.

---

## 📚 Referências
- Microsoft Docs – ASP.NET Core  
- Microsoft Docs – WCF  
- Swagger / OpenAPI  
- PostgreSQL Documentation  
