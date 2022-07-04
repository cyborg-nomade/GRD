# Gestão de Proposições - GPR

## Especificações Funcionais

Esse documento visa descrever os requisitos funcionais para o desenvolvimento de um novo sistema para Gestão de Proposições, a fim de substituir o atual módulo no SPI.

---

## 1. Níveis e Grupos de Acesso

O sistema deverá ter acesso diferenciado por níveis de senioridade e por grupos correspondentes às áreas funcionais da empresa, conforme abaixo:

### 1.1 Gerencial

O primeiro nível de acesso é o nível gerencial, ao qual terão acesso todos os gerentes da CPTM. Os gerentes poderão visualizar e editar apenas as Proposições que tiverem cadastrado para sua própria área.

### 1.2 Diretorias

O segundo nível de acesso é o nível das diretorias, ao qual terão acesso todos os diretores da CPTM. Os diretores poderão visualizar e editar todas as Proposições cadastradas pelas áreas subordinadas à sua diretoria, e serão responsáveis pela primeira aprovação e encaminhamento para adição da Proposição em pauta de RD.

### 1.3 GRG

O terceiro nível de acesso é o nível da GRG, ao qual terão acesso todos os empregados pertencentes à GRG (ou área que venha a substituí-la). Os membros da GRG poderão visualizar e editar todas as Proposições cadastradas por todos os demais usuários, e serão responsáveis pela inclusão destas nas pautas de RD. Este nível também poderá adicionar ou remover o acesso de usuários do sistema, assim como atribuir níveis e grupos de acesso.

---

## 2. Fluxo de Aprovação de Proposições

Esta seção descreve o fluxo principal de aprovação das Proposições.

### 2.1. Cadastramento de Proposição

O fluxo se inicia com o cadastramento da Proposição pelas gerências. Neste momento, o usuário poderá salvar seu progresso antes de encaminhar para aprovação.
Ao encaminhar para aprovação, o usuário deve ter preenchido todos os campos do formulário de Proposição corretamente, incluindo anexos. Neste momento, caso a Proposição esteja correta, ela aparecerá no sistema para o diretor responsável.  
Posteriormente, o gerente poderá visualizar o status atual da Proposição cadastrada e também editá-la enquanto ela não tiver sido incluída em pauta de RD. A ação de edição gerará notificações conforme descrito na [seção 4](#4-envio-de-notificações-por-e-mail).

### 2.2. Aprovação do Diretor Responsável

Na fase seguinte do fluxo, os diretores visualizarão uma listagem com todas as Proposições cadastradas pelas gerências, e deverão avaliá-las e aprová-las caso estejam de acordo. Será possível também editar as Proposições, caso necessário, até a inclusão em pauta de RD (o que gerará notificações conforme descrito na seção 4).  
Caso a Proposição seja aprovada, ela aparecerá para a GRG para a inclusão em pauta. Caso seja reprovada, ela mostrará o status "Reprovado" para o gerente que a cadastrou, e não mais aparecerá para o diretor em questão.

### 2.2. Inclusão em Pauta

A próxima fase do fluxo é a Inclusão em Pauta. Neste momento, os funcionários da GRG deverão abrir cada uma das Proposições cadastradas, avaliá-las quanto a corretude, e incluí-las na pauta da RD apropriada.  
Caso haja erros, a Proposição poderá ser retornada para a diretoria responsável. Caso contrário, ao ser incluída na pauta de uma RD, a Proposição aparecerá na **Tela de Reunião**, onde poderá ser tratada durante a Reunião de diretoria em questão.  
Neste momento, os funcionários da GRG também poderão emitir uma "Pauta Prévia" para a RD Prévia e, poteriormente, a "Pauta Definitiva" para a RD, na **Tela de Gestão de Reunião**.

### 2.3. Ações de RD

No momento da RD, os funcionários da GRG exibirão uma visualização apropriada (**Tela de Apresentação**), onde as seguintes ações estarão disponíveis:

-   **Aprovar**: Neste caso, a Proposição entre no status "Aprovada em RD".
-   **Retirar**: Neste caso, a Proposição volta ao status de "Inclusão em Pauta", e fica disponível para inclusão na pauta de uma nova RD.
-   **Suspenso**: Neste caso, a Proposição volta ao status de "Inclusão em Pauta", e fica disponível para inclusão na pauta de uma nova RD.
-   **Reprovado**: Neste caso, a Proposição entra no status "Reprovada em RD".

### 2.4. Ações Pós-RD

Após a conclusão da Reunião, os funcionários da GRG poderão executar as seguintes ações na **Tela de Gestão de Reunião**:

-   Acessar as Proposições daquela Reunião, para a elaboração da Ata e de outros relatórios;
-   Adicionar Proposições retroativamente;
-   Alterar os status das Proposições conforme necessário;
-   Anexar documentos à Reunião;
-   Emitir o Relatório Deliberativo ("Pauta Status"). Esta emissão trava a edição todas as Proposições na pauta, e realiza o arquivamento;

### 2.5. Arquivamento e Pesquisa

Após arquivada a Reunião e as Proposições relacionadas, elas não mais aparecem nas listagens correntes dos gerentes, diretores e da GRG, podendo ser acessadas apenas através de uma tela específica de pesquisa.  
Nenhuma edição pode ser realizada nos itens arquivados.

### 2.6. Sequência de Status

| #   | Nome                                  |
| --- | ------------------------------------- |
| 0   | Em Preenchimento                      |
| 1   | Em Aprovação da Diretoria Responsável |
| 1.1 | Reprovado pela Diretoria Responsável  |
| 2   | Disponível para Inclusão em Pauta     |
| 3   | Em Pauta                              |
| 4   | Aprovada em RD                        |
| 4.1 | Reprovada em RD                       |
| 4.2 | Aprovada em RD - Aguardando Ajustes   |
| 4.3 | Suspensa - Aguardando Ajustes         |
| 5   | Arquivada                             |

Os fluxos possíveis são:

0 > 1 > 1.1 > 1 > ... (Reprovação na Diretoria)

0 > 1 > 2 > 3 > 4 > 5 (Fluxo normal)

0 > 1 > 2 > 3 > 4.1 > 5 (Reprovação em RD)

0 > 1 > 2 > 3 > 4.2 > 4 > 5 (Realização de ajustes após aprovação)

0 > 1 > 2 > 3 > 4.3 > 2 > ... (Suspensão)

---

## 3. Descrição das Telas

Esta seção dá uma descrição detalhada de quais telas o sistema deverá apresentar no momento da entrega.

### 3.0. Tela de Login e Navegação

O sistema deverá inicialmente apresentar uma tela de login, com usuário e senha. O logo da CPTM deve aparecer ao lado deste formulário.  
O login deverá ser feito através do usuário e senha de rede utilizados normalmente para login nas máquinas da empresa.

Em todas as telas deve aparecer uma barra de navegação com links adequados para cada usuário, incluindo um link para logout. Essa barra deve aparecer fixa na parte superior da tela quando apresentada em telas maiores (notebooks, desktops), mas ser colapsada à direita em um ícone indicativo em visualizações menores (celulares, tablets).

### 3.1. Tela de Cadastro de Proposição

A tela de Casdastro de Proposição deverá conter um formulário com os seguintes campos e validações:

| Campo                        | Tipo                | Validação               |
| ---------------------------- | ------------------- | ----------------------- |
| Objeto                       | Dropdown            | Obrigatório             |
| Nº Proposição                | Texto               | Opcional                |
| Protolo                      | Texto               | Opcional                |
| Nº Processo                  | Texto               | Opcional                |
| Nº Reunião                   | Automático          | Opcional                |
| Data RD                      | Automático          | Opcional                |
| Seq.                         | Número              | Opcional                |
| IdPrd                        | Número / Automático | Opcional                |
| Assunto                      | Texto               | Obrigatório             |
| Nº Conselho                  | Texto               | Opcional                |
| Area Solicitante             | Dropdown            | Obrigatório             |
| Motivo Retorno               | Texto               | Opcional                |
| Vincular PRD?                | Checkbox            | Opcional                |
| Extra Pauta?                 | Checkbox            | Opcional                |
| Ação                         | Dropdown            | Obrigatório             |
| Sigla Gerência               | Texto / Automático  | Obrigatório             |
| Gerência                     | Texto / Automático  | Obrigatório             |
| Sigla Diretoria              | Texto / Automático  | Obrigatório             |
| Diretoria                    | Texto / Automático  | Obrigatório             |
| Área Atual                   | Texto / Automático  | Obrigatório             |
| Descrição Fluxo              | Texto               | Opcional                |
| Tempo Prev. Perm.            | Texto               | Opcional                |
| Status                       | Dropdown            | Obrigatório             |
| Desc. Próx. Passo            | Texto               | Opcional                |
| Tempo Perm. Próx.            | Texto               | Opcional                |
| Descrição                    | Texto               | Obrigatório             |
| Relator                      | Texto               | Obrigatório             |
| Data Base                    | Data                | Obrigatório             |
| Moeda                        | Texto               | Obrigatório             |
| Valor Original Contrato      | Número              | Obrigatório             |
| Valor Total Proposição       | Número              | Obrigatório             |
| PRD (Anexo)                  | Arquivo             | Obrigatório             |
| TR (Anexo)                   | Arquivo             | Obrigatório             |
| Parecer Jurídico (Anexo)     | Arquivo             | Obrigatório             |
| Relatório Técnico (Anexo)    | Arquivo             | Obrigatório             |
| Planilha Quant. (Anexo)      | Arquivo             | Obrigatório             |
| Edital (Anexo)               | Arquivo             | Obrigatório             |
| Reserva Verba (Anexo)        | Arquivo             | Obrigatório             |
| SC (Anexo)                   | Arquivo             | Obrigatório             |
| RAV (Anexo)                  | Arquivo             | Obrigatório             |
| Cronograma Fís.-Fin. (Anexo) | Arquivo             | Obrigatório             |
| PCA (Anexo)                  | Arquivo             | Obrigatório             |
| Outros (Anexo)               | Arquivos            | Opcionais               |
| Nº Contrato                  | Texto               | Opcional                |
| Termo                        | Texto               | Opcional                |
| Fornecedor                   | Texto               | Opcional                |
| Valor Atual Contrato         | Número              | Opcional                |
| Nº Reserva Verba             | Texto               | Opcional                |
| Valor Reserva Verba          | Número              | Opcional                |
| Início Vigência Reserva      | Data                | Opcional                |
| Fim Vigência Reserva         | Data                | Opcional                |
| Deliberação                  | Texto               | Obrigatório             |
| Resumo Geral                 | Texto               | Obrigatório             |
| Observações Custos           | Texto               | Obrigatório             |
| Competências Conforme Normas | Texto/Automático    | Obrigatório             |
| Nº Resolução                 | Número/Automático   | Opcional                |
| Assinatura Resolução         | Texto/Automático    | Opcional                |
| Resolução Diretoria          | Texto/Automático    | Opcional                |
| Resolução (Anexo)            | Arquivo             | Opcional                |
| Nome Aprovador               | Texto               | Obrigatório se aprovado |
| Função Aprovador             | Texto               | Obrigatório se aprovado |
| Data/Hora Aprovação          | Data/Hora           | Obrigatório se aprovado |
| Observações                  | Texto               | Opcional                |

Abaixo deste formulário, deverá haver uma série de botões, com cores indicativas, para a realização de ações de acordo com o nível de acesso do usuário e o status da Proposição.  
Todas as ações devem abrir um modal (pop-up), confirmando se o usuário deseja de fato executá-la. Caso clique em "Não", o modal apenas desaparece.  
Caso o usuário tente sair do formulário sem salvar as alterações, um modal (pop-up) deve aparecer informando que as informações preenchidas serão perdidas caso ele prossiga.

#### 3.1.1. Ações Gerenciais

Para as gerências, caso a Proposição esteja nos status _"Em Preenchimento"_ (status inicial), _"Reprovado pela Diretoria Responsável"_, _"Aprovada em RD - Aguardando Ajustes"_ ou _"Suspensa - Aguardando Ajustes"_, as ações são as seguintes:

-   **Salvar Progresso**: Salva o atual preenchimento do formulário, sem validações. Esta ação não altera o status da Proposição.
-   **Enviar para Aprovação da diretoria**: Verifica e valida o preenchimento correto do formulário, salva as alterações e muda o status para _"Em Aprovação da Diretoria Responsável"_. Nesse momento, uma notificação é enviada para o diretor responsável e para a GRG.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Cancelar**: Sai do formulário sem salvar as informações preenchidas.

Caso a Proposição esteja nos status _"Em Aprovação da Diretoria Responsável"_, _"Disponível para Inclusão em Pauta"_ ou _"Em Pauta"_, as ações são as seguintes:

-   **Salvar Alterações**: Verifica e valida o preenchimento correto do formulário e salva as alterações. Nesse momento, uma notificação é enviada para o diretor responsável e para a GRG.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Cancelar**: Sai do formulário sem salvar as informações preenchidas.

Caso a Proposição esteja nos status _"Aprovada em RD"_, _"Reprovada em RD"_ ou _"Arquivada"_, o formulário estará travado para edições, e as ações são as seguintes:

-   **Cancelar**: Sai do formulário.

#### 3.1.2. Ações da diretoria

Para as diretorias, caso a Proposição esteja no status _"Em Aprovação da Diretoria Responsável"_, as ações são as seguintes:

-   **Aprovar**: Verifica e valida o preenchimento correto do formulário, salva as alterações e muda o status para _"Disponível para Inclusão em Pauta"_. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para a GRG.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Reprovar**: Verifica e valida o preenchimento correto do formulário, salva as alterações e muda o status para _"Reprovado pela Diretoria Responsável"_. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Cancelar**: Sai do formulário sem salvar as informações preenchidas.

Caso a Proposição esteja nos status _"Reprovado pela Diretoria Responsável"_, _"Disponível para Inclusão em Pauta"_ ou _"Em Pauta"_, as ações são as seguintes:

-   **Salvar Alterações**: Verifica e valida o preenchimento correto do formulário e salva as alterações. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para a GRG.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Cancelar**: Sai do formulário sem salvar as informações preenchidas.

Caso a Proposição esteja nos status _"Aprovada em RD"_, _"Reprovada em RD"_ ou _"Arquivada"_, o formulário estará travado para edições e as ações são as seguintes:

-   **Cancelar**: Sai do formulário.

#### 3.1.3. Ações da GRG

Para os funcionários da GRG, as ações são as seguintes, caso a Proposição esteja no status _"Disponível para Inclusão em Pauta"_:

-   **Incluir em Pauta**: Abre um modal (pop-up) para selecionar, em uma lista suspensa, a Reunião na pauta da qual a Proposição deve ser incluída. A lista suspensa deve apresentar apenas reuniões que ainda não foram arquivadas.  
    Após selecionada a Reunião apropriada, o usuário deverá clicar em um botão "OK" dentro do modal, confirmando assim a inclusão. Ao clicar nele, o status da Proposição será alterado para _"Em Pauta"_, e os campos referentes à Reunião são preenchidos automaticamente no formulário.  
    Um botão "Cancelar" deverá ser exibido também. Neste caso, o modal se fecha, e nenhuma alteração é realizada.
-   **Salvar Alterações**: Verifica e valida o preenchimento correto do formulário e salva as alterações. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor responsável.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Cancelar**: Sai do formulário sem salvar as informações preenchidas.

Caso a Proposição esteja nos status _"Em Aprovação da Diretoria Responsável"_, _"Reprovado pela Diretoria Responsável"_, _"Em Pauta"_, _"Aprovada em RD - Aguardando Ajustes"_, _"Suspensa - Aguardando Ajustes"_ as ações são as seguintes:

-   **Salvar Alterações**: Verifica e valida o preenchimento correto do formulário e salva as alterações. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor Responsável.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Cancelar**: Sai do formulário sem salvar as informações preenchidas.

Caso a Proposição esteja nos status _"Aprovada em RD"_, _"Reprovada em RD"_ ou _"Arquivada"_, o formulário estará travado para edições e as ações são as seguintes:

-   **Cancelar**: Sai do formulário.

### 3.2. Listagem de Proposições Cadastradas

Como tela inicial para todos os usuários, será exibida uma listagem das Proposições já cadastradas no sistema, com uma filtragem inicial já definida pelo nível e grupo de acesso, e permitindo filtragens adicionais, além de algumas ações.  
Os filtros (tais como ordenação e pesquisa) serão disponibilizados acima da lista.  
A listagem deverá incluir os seguintes campos, servindo de resumo das Proposições:

| Campo                  |
| ---------------------- |
| Objeto                 |
| Nº Reunião             |
| Data RD                |
| IdPrd                  |
| Assunto                |
| Area Solicitante       |
| Descrição              |
| Relator                |
| Data Base              |
| Valor Total Proposição |
| Status                 |

Ao se clicar em uma das linhas da listagem, o sistema deverá abrir, na mesma tela, o **Formulário de Proposição** devidamente preenchido com as informações cadastradas, e disponibilizando as ações conforme seção anterior.

#### 3.2.1. Filtros e Gerenciais

A filtragem inicial para as Gerências deverá mostrar apenas as proposições não arquivadas que tenham sido cadastradas pela Gerência em questão.

O usuário poderá ainda pesquisar e ordernar pelos seguintes campos: ...

#### 3.2.2. Filtros e Ações da diretoria

A filtragem inicial para as diretorias deverá mostrar apenas as proposições não arquivadas que tenham sido cadastradas por Gerências subordinadas à diretoria em questão.

O usuário poderá ainda pesquisar e ordernar pelos seguintes campos: ...

#### 3.2.3. Filtros e Ações da GRG

A filtragem inicial para a GRG deverá mostrar apenas as proposições não arquivadas que tenham sido cadastradas pela Gerência em questão.

O usuário poderá ainda pesquisar e ordernar pelos seguintes campos: ...

### 3.3. Tela de Apresentação em RD (Tela de Reunião)

Para a GRG, será disponibilizada uma **Tela de Reunião**, a fim de facilitar a apresentação da pauta durante da RD.  
O acesso a essa tela será realizado através da barra de navegação. Ao clicar no link nessa barra, será apresentada uma lista com as reuniões disponíveis para apresentação. Ao selecionar uma das reuniões e clicar em "Apresentar", o usuário abrirá a **Tela de Reunião** em si.  
Essa tela consistirá de uma listagem similar às descritas na seção anterior, mas em tamanho aumentado, e contendo os seguintes campos: .... Abaixo da listagem, haverá um botão "Encerrar Reunião", que permitirá finalizar a apresentação.  
Ao se clicar em uma das linhas da listagem, o sistema deverá abrir, na mesma tela, o **Formulário de Proposição**, também em tamanho aumentado, devidamente preenchido com as informações cadastradas, e disponibilizando as seguintes ações abaixo do formulário:

-   **Aprovar**: Muda o status para _"Aprovada em RD"_. O sistema mostra um alerta de confirmação e, após fechado, volta à lista inicial, que já exibirá o novo status. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor Responsável.
-   **Reprovar**: Muda o status para _"Reprovada em RD"_. O sistema mostra um alerta de confirmação e, após fechado, volta à lista inicial, que já exibirá o novo status. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor Responsável.
-   **Suspender**: Muda o status para _"Reprovada em RD"_. O sistema mostra um alerta de confirmação e, após fechado, volta à lista inicial, que já exibirá o novo status. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor Responsável.
-   **Ajustes**: Abre um modal (pop-up), com uma caixa de texto, onde devem ser inseridos os ajustes necessários na Proposição. No modal, duas ações pode ser tomadas, a saber:
    -   _Aprovar_: Muda o status para _"Aprovada em RD - Aguardando Ajustes"_. O sistema mostra um alerta de confirmação e, após fechado, volta à lista inicial, que já exibirá o novo status. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor Responsável.
    -   _Suspender_: Muda o status para _"Suspensa - Aguardando Ajustes"_. O sistema mostra um alerta de confirmação e, após fechado, volta à lista inicial, que já exibirá o novo status. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor Responsável.
-   **Cancelar**: Sai do formulário sem fazer alterações, voltando à lista inicial.

### 3.4. Tela de Gestão de Reunião

Para a equipe da GRG, também será disponibilizada uma tela para a gestão das Reuniões. As Reuniões precisarão ser criadas usando esta tela antes que se possa incluir Proposições na sua pauta.  
Esta tela consistirá de um formulário com os seguintes campos e validações:

| Campo              | Tipo                   | Validação   |
| ------------------ | ---------------------- | ----------- |
| Nº Reunião         | Número / Automático    | Obrigatório |
| Data               | Data                   | Obrigatório |
| Horário            | Hora                   | Obrigatório |
| Status             | Dropdown               | Obrigatório |
| Data Prévia        | Data                   | Obrigatório |
| Horário Prévia     | Hora                   | Obrigatório |
| Local              | Texto                  | Obrigatório |
| Tipo Reunião       | Dropdown               | Obrigatório |
| Proposições        | Automático             | Opcional    |
| Proposições Prévia | Automático             | Opcional    |
| Participantes+     | Lista de Participantes | Opcional    |
| Outros Assuntos\*  | Lista de Ações         | Opcional    |
| Comunicado         | Texto                  | Opcional    |
| Outras Observações | Texto                  | Opcional    |
| Mensagem E-Mail    | Texto                  | Opcional    |
| Mensagem E-Mail    | Texto                  | Opcional    |

-   \+ O campo "Participantes" permitirá a criação de um Participantes, com os seguintes campos:
    | Campo | Tipo | Validação |
    | ----- | ---- | --------- |
    | Diretoria/Area | Texto | Obrigatório |
    | Nome | Texto | Obrigatório |
    | Email | Email | Obrigatório |

-   \* O campo "Outros Assuntos" permitirá a criação de uma ação, com os seguintes campos:
    | Campo | Tipo | Validação |
    | ----- | ---- | --------- |
    | Tipo | Dropdown | Obrigatório |
    | Diretoria Res. | Texto | Obrigatório |
    | Definição | Texto | Obrigatório |
    | Periodicidade | Dropdown | Opcional |
    | Prazo Inicial | Data | Obrigatório |
    | Status | Automático | Obrigatório |
    | Responsável | Texto | Obrigatório |
    | Email Diretor | Email | Obrigatório |
    | Nº Contrato | Texto | Opcional |
    | Fornecedor | Texto | Opcional |
    | Prazo Prorrogado (Dias) | Número | Opcional |
    | Prazo Final | Data | Opcional |
    | Dias p/ Vencimento | Número/Automático | Opcional |
    | Alerta Vencimento | Dropdown | Obrigatório |
    | Andamentos\*\* | Lista de Andamentos | Opcional |

    -   O campo "Andamentos" permitirá a criação de um andamento, com os seguintes campos:
        | Campo | Tipo | Validação |
        | ----- | ---- | --------- |
        | Data do Registro | Data | Obrigatório |
        | Responsável | Texto | Obrigatório |
        | Status | Dropdown/Automático | Obrigatório |
        | Descrição | Texto | Obrigatório |
        | Anexos | Lista de Arquivos | Opcional |

Abaixo deste formulário, deverá haver uma série de botões, com cores indicativas, para a realização de ações de acordo com o status da Reunião. A Reunião pederá ter os seguintes status:

| #   | Nome       |
| --- | ---------- |
| 0   | Em criação |
| 1   | Registrada |
| 2   | Prévia     |
| 3   | Pauta      |
| 4   | Realizada  |
| 5   | Arquivada  |

Caso a Reunião esteja no status _"Em criação"_, as ações serão as seguintes:

-   **Registrar**: Verifica e valida o preenchimento correto do formulário, registra a Reunião e muda seu status para _"Registrada"_.
-   **Cancelar**: Sai do formulário sem fazer alterações, voltando à tela inicial.

Caso a Reunião esteja nos demais status, as ações serão as seguintes:

-   **Salvar Alterações**: Verifica e valida o preenchimento correto do formulário e salva as alterações nos campos da Reunião.
-   **Emitir Pauta Prévia**: Emite o documento de pauta prévia, encaminhando-o para todos os participantes da Reunião, e muda o status da Reunião para _"Prévia"_. Esta ação não aparece caso o status seja _"Prévia"_.
-   **Emitir Pauta Definitiva**: Emite o documento de pauta definitiva, encaminhando-o para todos os participantes da Reunião, e muda o status da Reunião para _"Pauta"_. Esta ação não aparece caso o status seja _"Pauta"_.
-   **Emitir Relatório Deliberativo**: Emite o relatório deliberativo da RD, encaminhando-o para todos os participantes da Reunião, e muda o status da Reunião para _"Arquivada"_. Esta ação só aparece caso o status seja _"Realizada"_.
-   **Emitir Resoluções de Diretoria**: Emite a Resolução de Diretoria para cada Proposição da pauta da RD, encaminhando-o para todos os participantes da Reunião, assim como para o diretor e gerente responsáveis pela Proposição. A Resolução de Diretoria é criada a partir dos campos da Proposição, conforme modelo a ser disponibilizado pela GRG. Esta ação só aparece caso o status seja _"Realizada"_.
-   **Emitir Ata da Reunião**: Emite a Ata da RD, encaminhando-o para todos os participantes da Reunião. A Ata é criada a partir dos campos das Proposições em pauta, conforme modelo a ser disponibilizado pela GRG. Esta ação só aparece caso o status seja _"Realizada"_.
-   **Reunião Realizada**: Muda o status da Reunião para _"Realizada"_, eliminando a Reunião da listagem na **Tela de Reunião** e disponibilizando a ação anterior. Esta ação não aparece caso o status seja _"Realizada"_.
-   **Cancelar**: Sai do formulário sem fazer alterações, voltando à tela inicial.

### 3.5. Listagem de Reuniões

Será igualmente disponibilizado para a equipe da GRG uma listagem das Reuniões já cadastradas no sistema, permitindo filtragens.  
Os filtros (tais como ordenação e pesquisa) serão disponibilizados acima da lista.  
A listagem deverá incluir os seguintes campos, servindo de resumo das Reuniões:

| Campo           | Tipo                | Validação   |
| --------------- | ------------------- | ----------- |
| Id (Nº Reunião) | Número / Automático | Obrigatório |
| Data            | Data                | Obrigatório |
| Horário         | Hora                | Obrigatório |
| Status          | Dropdown            | Obrigatório |
| Local           | Texto               | Obrigatório |
| Tipo Reunião    | Dropdown            | Obrigatório |

Ao se clicar em uma das linhas da listagem, o sistema deverá abrir, na mesma tela, o **Formulário de Reuniões** devidamente preenchido com as informações cadastradas, e disponibilizando as ações conforme seção anterior.

## 4. Envio de Notificações por E-mail

O sistema deverá, nos momentos descritos abaixo, enviar notificações a certos usuários por e-mail.

### 4.1. Remetentes

Todos as notificações serão enviados do e-mail (...), que é uma conta já existente da GRG.

### 4.2. Destinatários

Conforme os eventos descritos na próxima seções, as notificações serão enviadas a gerentes e diretores em seus e-mails pessoais, definidos no AD CPTM. A GRG receberá notificações no e-mail de grupo (...), que distribuirá o conteúdo a seus membros.

### 4.3. Eventos de Acionamento

As notificações serão encaminhadas nas seguintes ocasiões:

-   **Cadastramento de Nova Proposição**: Quando um gerente cadastrar uma nova proposição, serão encaminhados e-mails para o diretor responsável pela área em questão, e à GRG.
-   **Alteração de Proposição**: Quando qualquer pessoa alterar uma proposição já registrada, serão encaminhados e-mails para o gerente que cadastrou a proposição alterada, para o diretor responsável pela área em questão, e à GRG.
-   **Aprovação de Proposição pela diretoria Responsável**: Quando o diretor aprovar uma proposição encaminhada à aprovação, serão encaminhados e-mails para o gerente que cadastrou a proposição, e à GRG.
-   **Inclusão de Proposição em pauta de RD**: Quando a GRG incluir uma proposição na pauta de uma Reunião, serão encaminhados e-mails para o gerente que cadastrou a proposição e para o diretor responsável pela área em questão.
-   **Deliberação em RD**: Quando a proposição for aprovada, reprovada, suspensa ou retirada da pauta, conforme deliberação em RD, serão encaminhados e-mails para o gerente que cadastrou a proposição e para o diretor responsável pela área em questão, assim como para todos os participantes da Reunião.
-   **Arquivamento de Proposição**: Quando a proposição for arquivada pela GRG, serão encaminhados e-mails para o gerente que cadastrou a proposição arquivada e para o diretor responsável pela área em questão.
-   **Envio de Pauta Prévia, Pauta Definitiva e Relatório Deliberativo**: Quando o envio desses documentos for realizado, serão encaminhados e-mails para os participantes da Reunião em questão.
