# Gestão de Reuniões de Diretoria - GRD

## Especificações Funcionais

Esse documento visa descrever os requisitos funcionais para o desenvolvimento de um novo sistema para Gestão de Reuniões de Diretoria, a fim de substituir o atual módulo de Gestão de Proposições no SPI.

---

## 1. Níveis e Grupos de Acesso

O sistema deverá ter acesso diferenciado por níveis de senioridade e por grupos correspondentes às áreas funcionais da empresa, conforme abaixo:

### 1.0 Sub-Gerencial

Este nível é de acesso para simples cadastro de Proposições, e deverá ser concedido pelos demais níveis, conforme necessidade da área.

### 1.1 Gerencial

O primeiro nível de acesso é o nível gerencial, ao qual terão acesso todos os gerentes da CPTM. Os gerentes poderão visualizar e editar apenas as Proposições que tiverem cadastrado para sua própria área. Os gerentes também poderão permitir acesso ao nível gerencial a seus assessores e secretários, através de interface do sistema.

### 1.2 Diretorias

O segundo nível de acesso é o nível das diretorias, ao qual terão acesso todos os diretores da CPTM. Os diretores poderão visualizar e editar todas as Proposições cadastradas pelas áreas subordinadas à sua diretoria, e serão responsáveis pela primeira aprovação e encaminhamento para adição da Proposição em pauta de RD. Os diretores também poderão permitir acesso ao nível de diretoria a seus assessores e secretários, através de interface do sistema.

### 1.3 GRG

O terceiro nível de acesso é o nível da GRG, ao qual terão acesso todos os empregados pertencentes à GRG (ou área que venha a substituí-la). Os membros da GRG poderão visualizar e editar todas as Proposições cadastradas por todos os demais usuários, e serão responsáveis pela inclusão destas nas pautas de RD. Este nível também poderá adicionar ou remover o acesso de usuários do sistema, assim como atribuir níveis e grupos de acesso, através de interface do sistema.

---

## 2. Ciclo de Vida de Proposições

A principal funcionalidade do sistema será gerir o fluxo de criação, aprovação e arquivamento das Proposições de Reunião de Diretoria. Esta seção descreve esse ciclo de vida.

### 2.1. Cadastramento de Proposição

O fluxo se inicia com o cadastramento da Proposição pelas gerências, ou áreas subordinadas. Neste momento, o usuário poderá salvar seu progresso antes de encaminhar para aprovação.  
Ao encaminhar para aprovação, o usuário deverá ter preenchido todos os campos do [Formulário de Proposição](#5.1.-formulário-de-proposição) corretamente, observando os campos e anexos obrigatório, assim como outras validações. Caso existam erros, o usuário receberá uma mensagem de erro indicando os campos incorretos ou ausentes. Caso a Proposição esteja correta, ela aparecerá no sistema para o diretor responsável.  
Posteriormente, o gerente poderá visualizar o status atual da Proposição cadastrada e também editá-la, enquanto ela não tiver sido incluída em pauta de RD. A ação de edição gerará notificações conforme descrito na [seção 6](#6-envio-de-notificações-por-e-mail).

### 2.2. Aprovação do Diretor Responsável

Na fase seguinte do fluxo, os diretores e demais usuários com acesso de direitoria visualizarão uma listagem com todas as Proposições cadastradas pelas gerências subordinadas, e deverão avaliá-las e aprová-las, caso estejam de acordo. Eles poderão também editar as Proposições, caso necessário, até o momento de inclusão em pauta de RD (o que gerará notificações conforme descrito na [seção 6](#6-envio-de-notificações-por-e-mail).  
Caso a Proposição seja aprovada, ela aparecerá para a GRG para a inclusão em pauta. Caso seja reprovada, ela mostrará o status _"Reprovado"_, assim como o motivo para a reprovação, para o gerente que a cadastrou, e não mais aparecerá para o diretor em questão.

### 2.2. Inclusão em Pauta

A próxima fase do fluxo é a Inclusão em Pauta. Neste momento, os funcionários da GRG deverão abrir cada uma das Proposições cadastradas, avaliá-las quanto a corretude, e incluí-las na pauta da RD apropriada.  
Caso haja erros, a Proposição poderá ser retornada para a diretoria responsável. Caso contrário, ao ser incluída na pauta de uma RD, a Proposição aparecerá na [**Tela de Reunião**](#53-tela-de-apresentação-em-rd-tela-de-reunião), onde poderá ser tratada durante a Reunião de Diretoria em questão.  
Neste momento, os funcionários da GRG também poderão emitir uma "Pauta Prévia" para a RD Prévia e, posteriormente, a "Pauta Definitiva" para a RD, na [**Tela de Gestão de Reunião**](#54-tela-de-gestão-de-reunião).

### 2.3. Atividades durante a Reunião de Diretoria

No momento da RD, os funcionários da GRG exibirão uma visualização apropriada ([**Tela de Apresentação**](#53-tela-de-apresentação-em-rd-tela-de-reunião)), onde estarão exibidas as Proposições incluídas na pauta daquela RD. Nesta tela, assim como na visualização dos diretores participantes da reunião, será possível realizar atividades de deliberação, alterando os status das Proposições, conforme especificado na seção [**Tela de Apresentação**](#53-tela-de-apresentação-em-rd-tela-de-reunião).

### 2.4. Atividades Pós-Reunião

Após a conclusão da Reunião, já com todas as Proposições deliberadas, os funcionários da GRG poderão executar as seguintes atividades na [**Tela de Gestão de Reunião**](#54-tela-de-gestão-de-reunião):

-   Acessar as Proposições daquela Reunião;
-   Adicionar Proposições retroativamente, assim como incluir as deliberações para eles;
-   Alterar os status das Proposições conforme necessário;
-   Emitir a Resolução de Diretoria para cada Proposição
-   Emitir a Ata da Reunião;
-   Emitir o Relatório Deliberativo ("Pauta Status").

### 2.5. Arquivamento e Pesquisa

Após arquivada a Reunião e as Proposições relacionadas, elas não mais aparecem nas listagens correntes dos gerentes, diretores e da GRG, podendo ser acessadas apenas através de uma tela específica de pesquisa no arquivo. Nenhuma edição pode ser realizada nos itens arquivados.  
O arquivo atual das Reuniões e Proposições, existente no SPI, será migrado para o novo sistema quando de sua implantação, a fim de facilitar a pesquisa de dados.

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

## 3. Ciclo de Vida de Ações

Além das Proposições, o sistema também permitirá a gestão de Ações: itens discutidos em Reunião de Diretoria que não são Proposições, mas que também exigem um acompanhamento de seu desenvolvimento. Esta seção descreve esse ciclo de vida.

### 3.1 Criação de Ações

As Ações serão inicialmente criadas pelos funcionários da GRG, durante ou após a execução da Reunião de Diretoria, para registrar um item debatido durante a Reunião, mas que não é uma Proposição. Essa Ação ficará vinculada inicialmente à Reunião em que foi criada, e especificará um responsável por lhe dar andamento, assim como uma data limite para sua execução, e uma data de próximo acompanhamento. Serão geradas notificações para os participantes da Reunião, para o responsável cadastrada da Ação, e para os membros da GRG, conforme especificado na [seção 6](#6-envio-de-notificações-por-e-mail). Ao ser cadastrada, a Ação se encontra no status _"Em Andamento"_.

### 3.2 Inclusão de Andamentos

Ao longo dos dias após a realização da Reunião em que a Ação foi cadastrada, até sua data limite, o responsável poderá incluir Andamentos, descrevendo a situação atual da Ação, entre outras informações pertinentes à sua conclusão.

### 3.3 Acompanhamento em Reunão de Diretoria

Os membros da GRG deverão incluir as Ações para acompanhamento em Reuniões próxima à data de próximo acompanhamento, ou à data limite. Ao fazerem isso, a Ação passa ao status _"Em Acompanhamento"_. Nesse status, a Ação ainda permite a inclusão de Andamentos por parte do responsável.

### 3.4 Conclusão e Encerramento de Ações

Durante ou após uma Reunião em que foi acompanhada, a Ação poderá ser dada como concluída, ou ser encerrada mesmo sem conclusão. Neste caso, os membros da GRG deverão especificar o status adequado (_"Concluída"_ ou _"Encerrada sem Conclusão"_). Após isso, a Ação não estará mais disponível para acompanhamento em outras Reuniões, e nenhum novo andamento poderá ser cadastrado.

### 3.5 Arquivamento e Pesquisa

As Ações concluídas ou encerradas também ficarão disponíveis para pesquisa em uma tela específica.  
O arquivo atual de Ações no SPI **_não será migrado_** para a nova aplicação, tendo em vista que a funcionalidade existente atualmente não corresponde à descrita aqui.

### 3.6 Sequência de Status

| #   | Nome                    |
| --- | ----------------------- |
| 0   | Em Andamento            |
| 1   | Em Acompanhamento       |
| 2   | Concluída               |
| 2.1 | Encerrada sem Conclusão |
| 3   | Arquivada               |

Os fluxos possíveis são:

0 > 1 > 2 > 3 (Fluxo normal)

0 > 1 > 2.1 > 3 (Encerramento sem Conclusão)

0 > 1 > (0 > 1...) > 2/2.1 > 3 (Acompanhamento ao longo de várias Reuniões)

---

## 4. Ciclo de Vida das Reuniões

De maneira mais geral, o sistema irá disponibilizar ferramentas para a gestão e realização de Reuniões de Diretoria, que também possuem um ciclo de vida, entre seu registro inicial e seu arquivamento. Esta seção descreve esse ciclo de vida.

### 4.1 Registro de Reuniões

Inicialmente, a Reunião será registrada pelos membros da GRG, em uma tela específica, onde são preenchidas informações sobre data e local de realização, entre outras. Ainda não é possível realizar a inclusão de Ações e Proposições. Ao registrar a Reunião entra no status _"Registrada"_.

### 4.2 Emissão de Pauta Prévia e Realização da Reunião Prévia

Após o registro inicial, a Reunião ficará disponível para inclusão de Proposições em sua pauta. Também fica disponível o cadastramento dos participantes da Reunião Prévia. Com esses dados, pode-se emitir a Pauta Prévia, que incluirá todas as Proposições cadastradas até aquele momento e mencionará os participantes cadastrados no campo "Participantes Prévia". Nesse momento a Reunião passa ao status _"Prévia"_ e é liberada a [**Tela de Apresentação Prévia**](#5.3.1.-tela-de-apresentação-prévia) para realização da Reunião Prévia, onde anotações podem ser realizadas, que constarão na _Memória da Prévia_.  
Após a realização da Reunião Prévia, será possível emitir a _Memória da Prévia_, com base nas informações registradas até aquele momento, seguindo o modelo a ser fornecido pela GRG.

### 4.3 Emissão de Pauta Definitiva e Realização da Reunião de Diretoria

Após a Reunião Prévia, a Reunião ainda pode receber a inclusao de novas Proposições em sua pauta. Também fica disponível o cadastramento dos participantes da Reunião principal. Com esses dados, pode-se emitir a Pauta Definitiva, que incluíra todas as Proposições cadastradas até aquele momento e será enviada aos e-mails dos participantes cadastrados. Nesse momento, a Reunião passa ao status _"Pauta"_ e é liberada a [**Tela de Apresentação**](#53-tela-de-apresentação-em-rd-tela-de-reunião).

### 4.4 Atividades Pós-Reunião e Emissão de Documentos

Durante e após a realização da Reunião de Diretoria, as Proposições receberão um status deliberativo (aprovada, suspensa, etc.). Quando todas as Proposições cadastradas na pauta de uma Reunião estiverem deliberadas, a Reunião passará ao status _"Realizada"_. Neste momento, torna-se possível emitir uma série de documentos vinculados à reunião, a saber:

-   Resoluções de Diretoria para cada Proposição;
-   Relatório de Ações, contendo as descrições de todas as Ações cadastradas naquela Reunião;
-   Ata, contendo as Resoluções para todas as Proposições, assim como as Ações;

Nesse status ainda é possível incluir Proposições retroativamente, assim como Ações.

### 4.5 Emissão de Relatório Deliberativo e Arquivamento da Reunião

Após a emissão de todos os documentos mencionados anteriormente, pode-se emitir o Relatório Deliberativo (Pauta Status) da Reunião. Esta emissão passa a Reunião para o status _"Arquivada"_, e bloqueia a Reunião e todas as Proposições em pauta para edição.

### 4.6 Sequência de Status

| #   | Nome       |
| --- | ---------- |
| 0   | Em criação |
| 1   | Registrada |
| 2   | Prévia     |
| 3   | Pauta      |
| 4   | Realizada  |
| 5   | Arquivada  |

---

## 5. Descrição das Telas

Esta seção dá uma descrição detalhada de quais telas o sistema deverá apresentar no momento da entrega.

### 5.0. Tela de Login e Navegação

O sistema deverá inicialmente apresentar uma tela de login, com usuário e senha. O logo da CPTM deve aparecer ao lado deste formulário.  
O login deverá ser feito através do usuário e senha de rede utilizados normalmente para login nas máquinas da empresa.

Em todas as telas deve aparecer uma barra de navegação com links adequados para cada usuário, incluindo um link para logout. Essa barra deve aparecer fixa na parte superior da tela quando apresentada em telas maiores (notebooks, desktops), mas ser colapsada à direita em um ícone indicativo em visualizações menores (celulares, tablets).

### 5.1. Formulário de Proposição

A tela de Casdastro de Proposição deverá conter um formulário com os seguintes campos e validações:

| Campo                        | Tipo                | Validação                                     |
| ---------------------------- | ------------------- | --------------------------------------------- |
| IdPrd                        | Número              | Automático                                    |
| Status                       | Dropdown            | Automático                                    |
| Area Solicitante             | Dropdown            | Obrigatório                                   |
| Sigla Gerência               | Texto               | Automático (Vem da área solicitante)          |
| Gerência                     | Texto               | Automático (Vem da área solicitante)          |
| Sigla Diretoria              | Texto               | Automático (Vem da área solicitante)          |
| Diretoria                    | Texto               | Automático (Vem da área solicitante)          |
| Relator                      | Texto               | Automático (Vem da área solicitante)          |
| Título                       | Texto               | Obrigatório                                   |
| Objeto                       | Dropdown            | Obrigatório                                   |
| Descrição Proposição         | Texto               | Obrigatório                                   |
| Possui Parecer Jurídico?     | Checkbox            | Obrigatório                                   |
| Resumo Geral da Resolução    | Texto               | Obrigatório                                   |
| Observações Custos           | Texto               | Obrigatório                                   |
| Competências Conforme Normas | Texto/Automático    | Obrigatório                                   |
| Data Base                    | Data                | Obrigatório                                   |
| Moeda                        | Texto               | Obrigatório                                   |
| Valor Original Contrato      | Número              | Obrigatório                                   |
| Valor Total Proposição       | Número              | Obrigatório                                   |
| Nº Contrato                  | Texto               | Opcional / Obrigatório (Dependente do Objeto) |
| Termo                        | Texto               | Opcional / Obrigatório (Dependente do Objeto) |
| Fornecedor                   | Texto               | Opcional / Obrigatório (Dependente do Objeto) |
| Valor Atual Contrato         | Número              | Opcional / Obrigatório (Dependente do Objeto) |
| Nº Reserva Verba             | Texto               | Opcional / Obrigatório (Dependente do Objeto) |
| Valor Reserva Verba          | Número              | Opcional / Obrigatório (Dependente do Objeto) |
| Início Vigência Reserva      | Data                | Opcional / Obrigatório (Dependente do Objeto) |
| Fim Vigência Reserva         | Data                | Opcional / Obrigatório (Dependente do Objeto) |
| Nº Proposição                | Texto               | Obrigatório                                   |
| Protolo/Expediente           | Texto               | Obrigatório                                   |
| Nº Processo (Licitação)      | Texto               | Opcional / Obrigatório (Dependente do Objeto) |
| Outras Observações           | Texto               | Opcional                                      |
| Nº Reunião                   | Número              | Automático (Vem da Reunião)                   |
| Data RD                      | Data                | Automático (Vem da Reunião)                   |
| Motivo Retorno               | Texto               | Automático (Vem da Reunião)                   |
| Deliberação                  | Texto               | Automático (Vem da Reunião)                   |
| Aprovações \+                | Lista de Aprovações | Automático (Exibição por Solicitação)         |
| Nº Resolução                 | Número              | Automático (Gerada na emissão da Resolução)   |
| Assinatura Resolução         | Texto               | Automático (Gerada na emissão da Resolução)   |
| Resolução Diretoria          | Texto               | Automático (Gerada na emissão da Resolução)   |
| Resolução (Anexo)            | Arquivo             | Automático (Gerada na emissão da Resolução)   |
| Extra Pauta?                 | Checkbox            | Opcional                                      |
| Nº Conselho                  | Texto               | Opcional                                      |
| Síntese do Processo (Anexo)  | Arquivo             | Opcional / Obrigatório (Dependente do Objeto) |
| Nota Técnica (Anexo)         | Arquivo             | Opcional / Obrigatório (Dependente do Objeto) |
| PRD (Anexo)                  | Arquivo             | Opcional / Obrigatório (Dependente do Objeto) |
| Parecer Jurídico (Anexo)     | Arquivo             | Opcional / Obrigatório (Dependente do Objeto) |
| TR (Anexo)                   | Arquivo             | Opcional / Obrigatório (Dependente do Objeto) |
| Relatório Técnico (Anexo)    | Arquivo             | Opcional / Obrigatório (Dependente do Objeto) |
| Planilha Quant. (Anexo)      | Arquivo             | Opcional / Obrigatório (Dependente do Objeto) |
| Edital (Anexo)               | Arquivo             | Opcional / Obrigatório (Dependente do Objeto) |
| Reserva Verba (Anexo)        | Arquivo             | Opcional / Obrigatório (Dependente do Objeto) |
| SC (Anexo)                   | Arquivo             | Opcional / Obrigatório (Dependente do Objeto) |
| RAV (Anexo)                  | Arquivo             | Opcional / Obrigatório (Dependente do Objeto) |
| Cronograma Fís.-Fin. (Anexo) | Arquivo             | Opcional / Obrigatório (Dependente do Objeto) |
| PCA (Anexo)                  | Arquivo             | Opcional / Obrigatório (Dependente do Objeto) |
| Outros (Anexo)               | Lista de Arquivos   | Opcionais                                     |
| Área Atual                   | Texto               | Automático (Sem Exibição)                     |
| Descrição Fluxo              | Texto               | Automático (Sem Exibição)                     |
| Tempo Prev. Perm.            | Texto               | Automático (Sem Exibição)                     |
| Desc. Próx. Passo            | Texto               | Automático (Sem Exibição)                     |
| Tempo Perm. Próx.            | Texto               | Automático (Sem Exibição)                     |
| Seq.                         | Número              | Opcional (Sem Exibição)                       |

-   \+ O campo "Aprovações" exibirá, caso requisitado, o registro das aprovações da Proposição, com os seguintes campos:
    | Campo | Tipo | Validação |
    | ----- | ---- | --------- |
    | Nome Aprovador | Texto | Obrigatório se aprovado |
    | Função Aprovador | Texto | Obrigatório se aprovado |
    | Data/Hora Aprovação | Data/Hora | Obrigatório se aprovado |

Abaixo deste formulário, deverá haver uma série de botões, com cores indicativas, para a realização de ações de acordo com o nível de acesso do usuário e o status da Proposição.  
Todas as ações devem abrir um modal (pop-up), confirmando se o usuário deseja de fato executá-la. Caso clique em "Não", o modal apenas desaparece.  
Caso o usuário tente sair do formulário sem salvar as alterações, um modal (pop-up) deve aparecer informando que as informações preenchidas serão perdidas caso ele prossiga.

#### 5.1.0 Atividades Subgerenciais

Para o nível subgerencial, independente do status da Proposição, as atividades serão apenas:

-   **Salvar Alterações**: Verifica e valida o preenchimento correto do formulário e salva as alterações. Nesse momento, uma notificação é enviada para o gerente responsável e para a GRG.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Cancelar**: Sai do formulário sem salvar as informações preenchidas.

#### 5.1.1. Atividades Gerenciais

Para as gerências, caso a Proposição esteja nos status _"Em Preenchimento"_ (status inicial), _"Reprovado pela Diretoria Responsável"_, _"Aprovada em RD - Aguardando Ajustes"_ ou _"Suspensa - Aguardando Ajustes"_, as atividades são as seguintes:

-   **Salvar Progresso**: Salva o atual preenchimento do formulário, sem validações. Esta ação não altera o status da Proposição.
-   **Enviar para Aprovação da diretoria**: Verifica e valida o preenchimento correto do formulário, salva as alterações e muda o status para _"Em Aprovação da Diretoria Responsável"_. Nesse momento, uma notificação é enviada para o diretor responsável e para a GRG.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Cancelar**: Sai do formulário sem salvar as informações preenchidas.

Caso a Proposição esteja nos status _"Em Aprovação da Diretoria Responsável"_, _"Disponível para Inclusão em Pauta"_ ou _"Em Pauta"_, as atividades são as seguintes:

-   **Salvar Alterações**: Verifica e valida o preenchimento correto do formulário e salva as alterações. Nesse momento, uma notificação é enviada para o diretor responsável e para a GRG.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Cancelar**: Sai do formulário sem salvar as informações preenchidas.

Caso a Proposição esteja nos status _"Aprovada em RD"_, _"Reprovada em RD"_ ou _"Arquivada"_, o formulário estará travado para edições, e as atividades são as seguintes:

-   **Cancelar**: Sai do formulário.

#### 5.1.2. Atividades da Diretoria

Para as diretorias, caso a Proposição esteja no status _"Em Aprovação da Diretoria Responsável"_, as atividades são as seguintes:

-   **Aprovar**: Verifica e valida o preenchimento correto do formulário, salva as alterações e muda o status para _"Disponível para Inclusão em Pauta"_. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para a GRG.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Reprovar**: Verifica e valida o preenchimento correto do formulário, salva as alterações e muda o status para _"Reprovado pela Diretoria Responsável"_. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Cancelar**: Sai do formulário sem salvar as informações preenchidas.

Caso a Proposição esteja nos status _"Reprovado pela Diretoria Responsável"_, _"Disponível para Inclusão em Pauta"_ ou _"Em Pauta"_, as atividades são as seguintes:

-   **Salvar Alterações**: Verifica e valida o preenchimento correto do formulário e salva as alterações. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para a GRG.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Cancelar**: Sai do formulário sem salvar as informações preenchidas.

Caso a Proposição esteja nos status _"Aprovada em RD"_, _"Reprovada em RD"_ ou _"Arquivada"_, o formulário estará travado para edições e as atividades são as seguintes:

-   **Cancelar**: Sai do formulário.

#### 5.1.3. Atividades da GRG

Para os funcionários da GRG, as atividades são as seguintes, caso a Proposição esteja no status _"Disponível para Inclusão em Pauta"_:

-   **Incluir em Pauta**: Abre um modal (pop-up) para selecionar, em uma lista suspensa, a Reunião na pauta da qual a Proposição deve ser incluída. A lista suspensa deve apresentar apenas reuniões que ainda não foram arquivadas.  
    Após selecionada a Reunião apropriada, o usuário deverá clicar em um botão "OK" dentro do modal, confirmando assim a inclusão. Ao clicar nele, o status da Proposição será alterado para _"Em Pauta"_, e os campos referentes à Reunião são preenchidos automaticamente no formulário.  
    Um botão "Cancelar" deverá ser exibido também. Neste caso, o modal se fecha, e nenhuma alteração é realizada.
-   **Salvar Alterações**: Verifica e valida o preenchimento correto do formulário e salva as alterações. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor responsável.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Cancelar**: Sai do formulário sem salvar as informações preenchidas.

Caso a Proposição esteja nos status _"Em Aprovação da Diretoria Responsável"_, _"Reprovado pela Diretoria Responsável"_, _"Em Pauta"_, _"Aprovada em RD - Aguardando Ajustes"_, _"Suspensa - Aguardando Ajustes"_ as atividades são as seguintes:

-   **Salvar Alterações**: Verifica e valida o preenchimento correto do formulário e salva as alterações. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor Responsável.  
    Em caso de erros de preenchimento, aparecerá um modal (pop-up) indicando que há erros no formulário, e os campos inválidos devem ser indicados.
-   **Cancelar**: Sai do formulário sem salvar as informações preenchidas.

Caso a Proposição esteja nos status _"Aprovada em RD"_, _"Reprovada em RD"_ ou _"Arquivada"_, o formulário estará travado para edições e as atividades são as seguintes:

-   **Cancelar**: Sai do formulário.

### 5.2. Listagem de Proposições Cadastradas

Como tela inicial para todos os usuários, será exibida uma listagem das Proposições já cadastradas no sistema, com uma filtragem inicial já definida pelo nível e grupo de acesso, e permitindo filtragens adicionais, além de algumas ações.  
O usuário poderá pesquisar e ordernar por todos os campos disponíveis na lista. Os controles para filtros (tais como ordenação e pesquisa) serão disponibilizados acima da lista.  
A listagem deverá incluir os seguintes campos, servindo de resumo das Proposições:

| Campo                  |
| ---------------------- |
| IdPrd                  |
| Area Solicitante       |
| Objeto                 |
| Título                 |
| Valor Total Proposição |
| Nº Reunião             |
| Data RD                |
| Status                 |

Ao se clicar em uma das linhas da listagem, o sistema deverá abrir, na mesma tela, o [**Formulário de Proposição**](#31-tela-de-cadastro-de-proposição) devidamente preenchido com as informações cadastradas, e disponibilizando as atividades conforme seção anterior.

#### 5.2.1. Filtros Gerenciais

A filtragem inicial para as Gerências deverá mostrar apenas as proposições não arquivadas que tenham sido cadastradas pela gerência em questão ou seus subordinados.

#### 5.2.2. Filtros da Diretoria

A filtragem inicial para as diretorias deverá mostrar apenas as proposições não arquivadas que tenham sido cadastradas por gerências subordinadas à diretoria em questão.

#### 5.2.3. Filtros e Ações da GRG

A filtragem inicial para a GRG deverá mostrar apenas as proposições não arquivadas que tenham sido cadastradas e esteja acima do status 2 - _"Disponível para Inclusão em Pauta"_. A GRG terá ainda uma tela mostrando apenas as proposições não arquivadas que tenham cadastradas e estejam abaixo do status 2 - _"Disponível para Inclusão em Pauta"_, e uma tela mostrando apenas as proposições arquivadas.

### 5.3. Tela de Apresentação em RD (Tela de Reunião)

Para a GRG, será disponibilizada uma **Tela de Reunião**, a fim de facilitar a apresentação da pauta durante da RD.  
O acesso a essa tela será realizado através da barra de navegação. Ao clicar no link nessa barra, será apresentada uma lista com as reuniões disponíveis para apresentação. Ao selecionar uma das reuniões e clicar em "Apresentar", o usuário abrirá a **Tela de Reunião** em si.  
Essa tela consistirá de uma listagem similar às descritas na [seção anterior](#5.2.-listagem-de-proposições-cadastradas), mas em tamanho aumentado. Abaixo da listagem, haverá um botão "Encerrar Reunião", que permitirá finalizar a apresentação.  
Ao se clicar em uma das linhas da listagem, o sistema deverá abrir, na mesma tela, o [**Formulário de Proposição**](#5.1.-formulário-de-proposição), também em tamanho aumentado, devidamente preenchido com as informações cadastradas, e disponibilizando as seguintes ações abaixo do formulário:

-   **Aprovar**: Muda o status para _"Aprovada em RD"_. O sistema mostra um alerta de confirmação e, após fechado, volta à lista inicial, que já exibirá o novo status. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor Responsável.
-   **Reprovar**: Muda o status para _"Reprovada em RD"_. O sistema mostra um alerta de confirmação e, após fechado, volta à lista inicial, que já exibirá o novo status. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor Responsável.
-   **Suspender**: Muda o status para _"Disponível para Inclusão em Pauta"_. O sistema mostra um alerta de confirmação e, após fechado, volta à lista inicial, que já exibirá o novo status. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor Responsável.
-   **Ajustes**: Abre um modal (pop-up), com uma caixa de texto, onde devem ser inseridos os ajustes necessários na Proposição. No modal, duas ações pode ser tomadas, a saber:
    -   _Aprovar_: Muda o status para _"Aprovada em RD - Aguardando Ajustes"_. O sistema mostra um alerta de confirmação e, após fechado, volta à lista inicial, que já exibirá o novo status. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor Responsável.
    -   _Suspender_: Muda o status para _"Suspensa - Aguardando Ajustes"_. O sistema mostra um alerta de confirmação e, após fechado, volta à lista inicial, que já exibirá o novo status. Nesse momento, uma notificação é enviada para o gerente que criou a Proposição e para o diretor Responsável.
-   **Cancelar**: Sai do formulário sem fazer alterações, voltando à lista inicial.

Essa mesma tela será disponibilizada em menu aos diretores participantes da Reunião, mas constando apenas as opções de **Aprovar** e **Reprovar**, através da qual será possível computar seus votos. Em evolução futura, o sistema não necessitaria das ações da GRG descritas acima, e deveria apenas calcular a aprovação/reprovação com base nos votos registrados pelo diretores diretamente em suas contas.

#### 5.3.1. Tela de Apresentação Prévia

Para a Reunião Prévia, será disponibilizada uma tela similar à anterior, mas sem as atividades descritas. Nela constará apenas, para cada Proposição, a opção de adicionar anotações, que serão feitas durante a apresentação dos participantes da prévia. O documento de _"Memória da Prévia"_ será construído principalmente a partir dos dados apresentados nesta tela.

### 5.4. Tela de Gestão de Reunião

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

Abaixo deste formulário, deverá haver uma série de botões, com cores indicativas, para a realização de ações de acordo com o status da Reunião.

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

### 5.5. Listagem de Reuniões

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

## 6. Envio de Notificações por E-mail

O sistema deverá, nos momentos descritos abaixo, enviar notificações a certos usuários por e-mail.

### 6.1. Remetentes

Todos as notificações serão enviados do e-mail "governanca@cptm.sp.gov.br", que é uma conta já existente da GRG.

### 6.2. Destinatários

Conforme os eventos descritos na próxima seções, as notificações serão enviadas a gerentes e diretores em seus e-mails pessoais, definidos no AD CPTM. A GRG receberá notificações no e-mail de grupo "governanca@cptm.sp.gov.br", que distribuirá o conteúdo a seus membros.

### 6.3. Eventos de Acionamento

As notificações serão encaminhadas nas seguintes ocasiões:

-   **Cadastramento de Nova Proposição**: Quando um gerente cadastrar uma nova proposição, serão encaminhados e-mails para o diretor responsável pela área em questão, e à GRG.
-   **Alteração de Proposição**: Quando qualquer pessoa alterar uma proposição já registrada, serão encaminhados e-mails para o gerente que cadastrou a proposição alterada, para o diretor responsável pela área em questão, e à GRG.
-   **Aprovação de Proposição pela diretoria Responsável**: Quando o diretor aprovar uma proposição encaminhada à aprovação, serão encaminhados e-mails para o gerente que cadastrou a proposição, e à GRG.
-   **Inclusão de Proposição em pauta de RD**: Quando a GRG incluir uma proposição na pauta de uma Reunião, serão encaminhados e-mails para o gerente que cadastrou a proposição e para o diretor responsável pela área em questão.
-   **Deliberação em RD**: Quando a proposição for aprovada, reprovada, suspensa ou retirada da pauta, conforme deliberação em RD, serão encaminhados e-mails para o gerente que cadastrou a proposição e para o diretor responsável pela área em questão, assim como para todos os participantes da Reunião.
-   **Arquivamento de Proposição**: Quando a proposição for arquivada pela GRG, serão encaminhados e-mails para o gerente que cadastrou a proposição arquivada e para o diretor responsável pela área em questão.
-   **Criação de Ação**: Quando uma Ação for criada em uma Reunião, serão encaminhados e-mails aos participantes da Reunião, ao responsável designado e aos membros da GRG.
-   **Inclusão de Andamento**: Quando um Andamento for criado em uma Ação, serão encaminhados e-mails aos participantes da Reunião em que a Ação está inclusa, ao responsável designado e aos membros da GRG.
-   **Envio de Pauta Prévia, Pauta Definitiva e Relatório Deliberativo**: Quando o envio desses documentos for realizado, serão encaminhados e-mails para os participantes da Reunião em questão.
