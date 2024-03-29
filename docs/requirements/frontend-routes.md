# 0. tela inicial

-   **/login/**: login homepage.

# 1. acesso subgerencial

-   **/sub/:uid:/**: sub homepage. shows list of user's registered Proposicoes that haven't been archived;
-   **/sub/:uid:/proposicao**: shows list of user's registered Proposicoes that haven't been archived;
-   **/sub/:uid:/proposicao/aprovadas-rd**: shows list of user's registered Proposicoes that have been rd-approved;
-   **/sub/:uid:/proposicao/revisao**: shows list of user's registered Proposicoes that need review;
-   **/sub/:uid:/proposicao/arquivo**: shows list of user's registered Proposicoes that have been archived;
-   **/sub/:uid:/proposicao/novo**: empty Proposicao form, with sub activities (save/cancel);
-   **/sub/:uid:/proposicao/:pid:/**: Proposicao form for registered Proposicao, with sub activities (save/cancel);
-   **/sub/:uid:/acao/**: shows list of all acoes under user's responsibility;
-   **/sub/:uid:/acao/em-andamento**: shows list of all acoes under user's responsibility that are ongoing;
-   **/sub/:uid:/acao/arquivo**: shows list of all acoes under user's responsibility that have been archived;
-   **/sub/:uid:/acao/:aid:**: Acao form for registered Acao, with sub activities;

# 2. acesso gerencial

-   **/gerente/:uid:/**: gerente homepage. shows list of user's registered Proposicoes that haven't been archived;
-   **/gerente/:uid:/proposicao**: shows list of user's registered Proposicoes that haven't been archived;
-   **/gerente/:uid:/proposicao/novas**: shows list of user's newly registered Proposicoes;
-   **/gerente/:uid:/proposicao/aprovadas-rd**: shows list of user's registered Proposicoes that have been rd-approved;
-   **/gerente/:uid:/proposicao/revisao**: shows list of user's registered Proposicoes that need review;
-   **/gerente/:uid:/proposicao/arquivo**: shows list of user's registered Proposicoes that have been archived;
-   **/gerente/:uid:/proposicao/novo**: empty Proposicao form, with gerente activities (save/cancel);
-   **/gerente/:uid:/proposicao/:pid:/**: Proposicao form for registered Proposicao, with gerente activities (save/cancel);
-   **/gerente/:uid:/acao/**: shows list of all acoes under user's responsibility;
-   **/gerente/:uid:/acao/em-andamento**: shows list of all acoes under user's responsibility that are ongoing;
-   **/gerente/:uid:/acao/arquivo**: shows list of all acoes under user's responsibility that have been archived;
-   **/gerente/:uid:/acao/:aid:**: Acao form for registered Acao, with gerente activities;
-   **/gerente/:uid:/acessos/**: list of all users subordinated to gerente;
-   **/gerente/:uid:/acessos/:euid:**: User form for registered User, with gerente activities for mgmt;

# 3. acesso assessor-diretoria

-   **/assessor-diretoria/:uid:/**: assessor-diretoria homepage. shows list of all subordinate area's registered Proposicoes that haven't been archived;
-   **/assessor-diretoria/:uid:/proposicao**: shows list of user's registered Proposicoes that haven't been archived;
-   **/assessor-diretoria/:uid:/proposicao/aprovacao**: shows list of Proposicoes that need approval;
-   **/assessor-diretoria/:uid:/proposicao/aprovadas-rd**: shows list of user's registered Proposicoes that have been rd-approved;
-   **/assessor-diretoria/:uid:/proposicao/revisao**: shows list of user's registered Proposicoes that need review;
-   **/assessor-diretoria/:uid:/proposicao/arquivo**: shows list of user's registered Proposicoes that have been archived;
-   **/assessor-diretoria/:uid:/proposicao/novo**: empty Proposicao form, with assessor activities (save/cancel);
-   **/assessor-diretoria/:uid:/proposicao/:pid:/**: Proposicao form for registered Proposicao, with assessor activities (save/cancel);
-   **/assessor-diretoria/:uid:/acao/**: shows list of all acoes under user's responsibility;
-   **/assessor-diretoria/:uid:/acao/em-andamento**: shows list of all acoes under user's responsibility that are ongoing;
-   **/assessor-diretoria/:uid:/acao/arquivo**: shows list of all acoes under user's responsibility that have been archived;
-   **/assessor-diretoria/:uid:/acao/:aid:**: Acao form for registered Acao, with assessor-diretoria activities;
-   **/assessor-diretoria/:uid:/reuniao/**: List of Reunioes, showing list of upcoming Reunioes in Prévia status;
-   **/assessor-diretoria/:uid:/reuniao/:rid:/apresentacao/previa**: Reuniao Previa presentation screen, showing Proposicoes for that Reuniao;
-   **/assessor-diretoria/:uid:/reuniao/:rid:/apresentacao/previa/proposicao/:pid:/**: Proposicao form, with Previa activities (annotation);

# 4. acesso de diretoria

-   **/diretoria/:uid:/**: diretoria homepage. shows list of all subordinate area's registered Proposicoes that haven't been archived;
-   **/diretoria/:uid:/proposicao**: shows list of user's registered Proposicoes that haven't been archived;
-   **/diretoria/:uid:/proposicao/aprovacao**: shows list of Proposicoes that need approval;
-   **/diretoria/:uid:/proposicao/aprovadas-rd**: shows list of user's registered Proposicoes that have been rd-approved;
-   **/diretoria/:uid:/proposicao/revisao**: shows list of user's registered Proposicoes that need review;
-   **/diretoria/:uid:/proposicao/arquivo**: shows list of user's registered Proposicoes that have been archived;
-   **/diretoria/:uid:/proposicao/novo**: empty Proposicao form, with diretoria activities (save/cancel);
-   **/diretoria/:uid:/proposicao/:pid:/**: Proposicao form for registered Proposicao, with diretoria activities (save/cancel);
-   **/diretoria/:uid:/acao/**: shows list of all acoes under user's responsibility;
-   **/diretoria/:uid:/acao/em-andamento**: shows list of all acoes under user's responsibility that are ongoing;
-   **/diretoria/:uid:/acao/arquivo**: shows list of all acoes under user's responsibility that have been archived;
-   **/diretoria/:uid:/acao/:aid:**: Acao form for registered Acao, with diretoria activities;
-   **/diretoria/:uid:/reuniao/**: List of Reunioes, showing list of upcoming Reunioes in Prévia status;
-   **/diretoria/:uid:/reuniao/:rid:/apresentacao**: Reuniao presentation screen, showing Proposicoes for that Reuniao;
-   **/diretoria/:uid:/reuniao/:rid:/apresentacao/proposicao/:pid:/**: Proposicao form, with RD activities (approve/repprove/etc);
-   **/diretoria/:uid:/acessos/**: list of all users subordinated to diretoria;
-   **/diretoria/:uid:/acessos/:euid:**: User form for registered User, with diretoria activities for mgmt;

# 5. acesso grg

-   **/grg/:uid:/**: grg homepage. shows list of all registered Proposicoes that haven't been archived;
-   **/grg/:uid:/proposicao**: shows list of all registered Proposicoes that haven't been archived;
-   **/grg/:uid:/proposicao/disponiveis**: shows list of all Proposicoes that available to be included in Reuniao;
-   **/grg/:uid:/proposicao/inclusas-rd**: shows list of all registered Proposicoes that have been included in a Reuniao;
-   **/grg/:uid:/proposicao/revisao**: shows list of all registered Proposicoes that need review;
-   **/grg/:uid:/proposicao/aprovacao**: shows list of all registered Proposicoes that need to be approved;
-   **/grg/:uid:/proposicao/arquivo**: shows list of all registered Proposicoes that have been archived;
-   **/grg/:uid:/proposicao/novo**: empty Proposicao form, with grg activities (save/cancel);
-   **/grg/:uid:/proposicao/:pid:/**: Proposicao form for registered Proposicao, with grg activities (save/cancel);
-   **/grg/:uid:/reuniao/**: List of Reunioes, showing list of all Reunioes in descending order of data, initially with only the latest 10;
-   **/grg/:uid:/reuniao/registradas**: List of Reunioes, showing list of all Reunioes in "registrada" status in descending order of data, initially with only the latest 10;
-   **/grg/:uid:/reuniao/arquivo**: List of Reunioes, showing list of all archived Reunioes in descending order of data, initially with only the latest 10;
-   **/grg/:uid:/reuniao/nova**: empty Reuniao form, with grg activities;
-   **/grg/:uid:/reuniao/:rid:/**: Reuniao form for registered Reuniao, with grg activities;
-   **/grg/:uid:/reuniao/:rid:/apresentacao/**: Reuniao presentation screen, showing Proposicoes for that Reuniao;
-   **/grg/:uid:/reuniao/:rid:/apresentacao/previa**: Reuniao Previa presentation screen, showing Proposicoes for that Reuniao;
-   **/grg/:uid:/reuniao/:rid:/apresentacao/previa/proposicao/:pid:/**: Proposicao form, with grg Previa activities (annotations);
-   **/grg/:uid:/reuniao/:rid:/apresentacao/proposicao/:pid:/**: Proposicao form, with grg RD activities (approve/repprove/etc);
-   **/grg/:uid:/acao/**: shows list of all acoes under user's responsibility;
-   **/grg/:uid:/acao/em-andamento**: shows list of all acoes that are ongoing;
-   **/grg/:uid:/acao/arquivo**: shows list of all acoes that have been archived;
-   **/grg/:uid:/acao/nova**: empty Acao form, with grg activities;
-   **/grg/:uid:/acao/:aid:**: Acao form for registered Acao, with diretoria activities;
-   **/grg/:uid:/acessos/**: User mgmt cockpit, showing all users and their access levels and groups, and allowing to add, edit and remove;
-   **/grg/:uid:/acessos/:euid:**: User form for registered User, with grg activities for mgmt;

# 6. acesso SysAdmin

-   **/admin/**: admin home page. shows options to enter all of the levels views + admin;
-   **/admin/acessos/**: shows list of all users and their levels and groups, allowing add, edit and remove;
-   **/admin/acessos/:euid:**: User form for registered User, with grg activities for mgmt;
-   **/admin/proposicoes/**: list of all Proposicoes;
-   **/admin/proposicoes/:pid:/**: Proposicao form for registered Proposicao, with all actions;
-   **/admin/reuniao/**: list of all Reunioes;
-   **/admin/reuniao/:rid:/**: Reuniao form for registered Reuniao, with all actions;
-   **/admin/acoes/**: list of all Acoes;
-   **/admin/acoes/:aid:/**: Acoes form for registered Acoes, with all actions;
