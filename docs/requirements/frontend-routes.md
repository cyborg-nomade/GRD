# 0. tela inicial

-   **/login/**: login homepage.

# 1. acesso subgerencial

-   **/sub/:uid:/**: sub homepage. shows list of user's registered Proposicoes that haven't been archived;
-   **/sub/:uid:/novo**: empty Proposicao form, with sub activities (save/cancel);
-   **/sub/:uid:/proposicao/:pid:/**: Proposicao form for registered Proposicao, with sub activities (save/cancel);

# 2. acesso gerencial

-   **/gerente/:uid:/**: gerente homepage. shows list of area's registered Proposicoes that haven't been archived;
-   **/gerente/:uid:/novo**: empty Proposicao form, with gerente activities (save/send to diretoria approval/cancel);
-   **/gerente/:uid:/proposicao/:pid:/**: Proposicao form for registered Proposicao, with gerente activities (save/send to diretoria approval/cancel);
-   **/gerente/:uid:/acessos/**: User mgmt cockpit, showing users allowed with sub acess, and allowing to add and remove individually;

# 3. acesso de diretoria

-   **/diretoria/:uid:/**: diretor homepage. shows list of all subordinate area's registered Proposicoes that haven't been archived;
-   **/diretoria/:uid:/novo**: empty Proposicao form, with diretor activities (approve/repprove/save/cancel);
-   **/diretoria/:uid:/proposicao/:pid:/**: Proposicao form for registered Proposicao, with diretoria activities (approve/repprove/save/cancel);
-   **/diretoria/:uid:/acessos/**: User mgmt cockpit, showing users allowed with equal diretor acess, and allowing to add and remove;
-   **/diretoria/:uid:/rd/**: List of Reunioes, showing list of upcoming Reunioes in Pauta status;
-   **/diretoria/:uid:/rd/:rid:/apresentacao/**: Reuniao presentation screen, showing Proposicoes for that Reuniao;
-   **/diretoria/:uid:/rd/:rid:/apresentacao/proposicao/:pid:/**: Proposicao form, with RD activities (approve/repprove/etc);

# 4. acesso assessor-diretoria

-   **/assessor-diretoria/:uid:/**: assessor-diretoria homepage. shows list of all subordinate area's registered Proposicoes that haven't been archived;
-   **/assessor-diretoria/:uid:/novo**: empty Proposicao form, with assessor-diretoria activities (approve/repprove/save/cancel);
-   **/assessor-diretoria/:uid:/proposicao/:pid:/**: Proposicao form for registered Proposicao, with assessor-diretoria activities (approve/repprove/save/cancel);
-   **/assessor-diretoria/:uid:/rd/**: List of Reunioes, showing list of upcoming Reunioes in Prévia status;
-   **/assessor-diretoria/:uid:/rd/:rid:/apresentacao/previa**: Reuniao Previa presentation screen, showing Proposicoes for that Reuniao;
-   **/assessor-diretoria/:uid:/rd/:rid:/apresentacao/previa/proposicao/:pid:/**: Proposicao form, with Previa activities (annotation);

# 5. acesso grg

-   **/grg/:uid:/**: grg homepage. shows list of all registered Proposicoes that haven't been archived;
-   **/grg/:uid:/novo**: empty Proposicao form, with grg activities (include in Reuniao/save/cancel);
-   **/grg/:uid:/proposicao/:pid:/**: Proposicao form for registered Proposicao, with grg activities;
-   **/grg/:uid:/acessos/**: User mgmt cockpit, showing all users and their access levels and groups, and allowing to add, edit and remove;
-   **/grg/:uid:/rd/**: List of Reunioes, showing list of all Reunioes in descending order of data, initially with only the latest 10;
-   **/grg/:uid:/rd/novo**: empty Reuniao form, with grg activities;
-   **/grg/:uid:/rd/:rid:/**: Reuniao form for registered Reuniao, with grg activities;
-   **/grg/:uid:/rd/:rid:/apresentacao/**: Reuniao presentation screen, showing Proposicoes for that Reuniao;
-   **/grg/:uid:/rd/:rid:/apresentacao/previa**: Reuniao Previa presentation screen, showing Proposicoes for that Reuniao;
-   **/grg/:uid:/rd/:rid:/apresentacao/previa/proposicao/:pid:/**: Proposicao form, with grg Previa activities (annotations);
-   **/grg/:uid:/rd/:rid:/apresentacao/proposicao/:pid:/**: Proposicao form, with grg RD activities (approve/repprove/etc);

# 6. acesso SysAdmin

-   **/admin/acessos/**: shows list of all users and their levels and groups, allowing add, edit and remove;
-   **/admin/proposicoes/**: list of all Proposicoes;
-   **/admin/proposicoes/:pid:/**: Proposicao form for registered Proposicao, with all actions;
-   **/admin/proposicoes/:pid:/aprovacoes**: list of all Aprovacoes of a Proposicao;
-   **/admin/proposicoes/:pid:/info**: list of all technical infos of a Proposicao;
-   **/admin/reunioes/**: list of all Reunioes;
-   **/admin/reunioes/:rid:/**: Reuniao form for registered Reuniao, with all actions;
-   **/admin/acoes/**: list of all Acoes;
-   **/admin/acoes/:aid:/**: Acoes form for registered Acoes, with all actions;
