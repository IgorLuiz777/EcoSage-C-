
<p align="center" style="display: flex; justify-content: center;">
  <img src="https://media.discordapp.net/attachments/1304125766887276604/1308856876439572550/ecosage_logo.png?ex=674171b4&is=67402034&hm=fce0a632d43ddfa69bf2c509331b04008fef87cc0df3be406db82132534e282d&=&format=webp&quality=lossless&width=629&height=416" alt="EcoSage - LOGO" style="border-radius: 15px;" />
</p>

# EcoSage - Sistema de Cálculo de Pegada de Carbono 🌱

## Descrição do Projeto

EcoSage é um sistema desenvolvido com o objetivo de calcular e otimizar a pegada de carbono, proporcionando aos usuários uma visão detalhada sobre o impacto ambiental das suas atividades. Através de uma API em Java e C#, o sistema permite registrar, monitorar e atualizar atividades relacionadas ao consumo de energia e transporte, assim como calcular a pegada de carbono associada. O objetivo é ajudar os usuários a reduzir seus impactos ambientais de maneira prática e eficiente.

## Funcionalidades Principais

### 1. **Gerenciamento de Atividades**
   - **Atividade Energética**: Registro de atividades relacionadas ao consumo de energia.
   - **Atividade de Transporte**: Registro de atividades de transporte, como viagens e deslocamentos.
   - **Visualização e Exclusão**: Recuperação de atividades registradas e possibilidade de deletá-las.

### 2. **Cálculo de Pegada de Carbono**
   - **Criação e Atualização de Pegada de Carbono**: Cálculo da pegada de carbono com base nas atividades registradas.
   - **Visualização da Pegada de Carbono**: Consulta de pegadas de carbono por ID.
   - **Remoção de Pegada de Carbono**: Exclusão de pegadas de carbono que não são mais relevantes.

### 3. **Interação com a IA**
   - **EcoSage AI**: Um chatbot inteligente que auxilia os usuários com cálculos de pegada de carbono, oferece recomendações e responde a dúvidas sobre sustentabilidade.

## Endpoints da API

### Atividades
- **POST** `/ecosage/Activity/energy`: Adiciona uma nova atividade de energia.
- **POST** `/ecosage/Activity/transport`: Adiciona uma nova atividade de transporte.
- **GET** `/ecosage/Activity`: Recupera todas as atividades.
- **GET** `/ecosage/Activity/{id}`: Recupera uma atividade específica pelo ID.
- **DELETE** `/ecosage/Activity/{id}`: Exclui uma atividade específica pelo ID.

### IA
- **POST** `/ecosage/Ai/message`: Envia uma mensagem para a IA e recebe uma resposta.

### Pegada de Carbono
- **GET** `/ecosage/carbonfootprints`: Recupera todas as pegadas de carbono.
- **POST** `/ecosage/carbonfootprints`: Cria uma nova pegada de carbono.
- **GET** `/ecosage/carbonfootprints/{id}`: Recupera uma pegada de carbono específica pelo ID.
- **PUT** `/ecosage/carbonfootprints/{id}`: Atualiza uma pegada de carbono existente.
- **DELETE** `/ecosage/carbonfootprints/{id}`: Exclui uma pegada de carbono pelo ID.

### Usuários
- **GET** `/ecosage/Users`: Recupera todos os usuários.
- **POST** `/ecosage/Users`: Cria um novo usuário.
- **GET** `/ecosage/Users/{id}`: Recupera um usuário pelo seu ID.
- **PUT** `/ecosage/Users/{id}`: Atualiza um usuário pelo seu ID.
- **DELETE** `/ecosage/Users/{id}`: Exclui um usuário pelo seu ID.

Confira o vídeo do nosso projeto no link abaixo:  
[Assista ao Pitch](https://youtu.be/)

Projeto Java: [GITHUB](https://github.com/IgorLuiz777/EcoSageAPI-java)

Interface: [GITHUB](https://github.com/IgorLuiz777/EcoSage-front)

Projeto Mobile: [GITHUB](https://github.com/lucasrychlicki/EcoSage)

Projeto IA: [GITHUB](https://github.com/CastanhoPh/Ecosage)


## Sobre a Equipe

- **Gustavo Monte (RM 551601)** - Compliance, Quality Assurance & Tests
- **Igor Luiz (RM 99809)** - Java Advanced | Advanced Business Development with .NET
- **Lucas Lima (RM 551253)** - Mobile Application Development | DevOps Tools & Cloud Computing
- **Murilo Caumo (RM 551247)** - Mastering Relational and Non-Relational Databases
- **Pedro Henrique (RM 551598)** - Disruptive Architectures: IoT, IoB & Generative AI

## Como Contribuir

1. Faça um fork do repositório.
2. Crie uma branch para sua feature (git checkout -b minha-feature).
3. Faça commit das suas alterações (git commit -m 'Adicionei uma nova feature').
4. Faça o push para a branch (git push origin minha-feature).
5. Abra um Pull Request.

