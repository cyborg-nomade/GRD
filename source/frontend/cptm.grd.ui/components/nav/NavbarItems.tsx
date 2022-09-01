import {
    ListItem,
    ListItemButton,
    ListItemIcon,
    ListItemText,
} from "@mui/material";
import { AccessLevel } from "models/common.model";
import { useRouter } from "next/router";
import React from "react";
import { useAppSelector } from "services/redux/hooks";
import HomeIcon from "@mui/icons-material/Home";
import ArticleIcon from "@mui/icons-material/Article";
import NoteAddIcon from "@mui/icons-material/NoteAdd";
import PersonIcon from "@mui/icons-material/Person";
import CheckCircleIcon from "@mui/icons-material/CheckCircle";
import VisibilityIcon from "@mui/icons-material/Visibility";
import InventoryIcon from "@mui/icons-material/Inventory";
import PlaylistAddCheckIcon from "@mui/icons-material/PlaylistAddCheck";
import HourglassBottomIcon from "@mui/icons-material/HourglassBottom";
import LoginIcon from "@mui/icons-material/Login";
import NotificationsActiveIcon from "@mui/icons-material/NotificationsActive";
import {
    Approval,
    BookmarkAdded,
    DensitySmall,
    EventAvailable,
    GroupAdd,
    Groups,
    MeetingRoom,
    PeopleOutline,
    PlaylistAdd,
    Today,
    List,
    Logout,
} from "@mui/icons-material";

type NavItem = {
    icon: JSX.Element;
    name: string;
    link: string;
    indent: number;
};

const NavbarItems = () => {
    const authState = useAppSelector((state) => state.auth);
    const router = useRouter();

    let navItems: NavItem[] = [
        { icon: <HomeIcon />, name: "Início", link: "/", indent: 0 },
    ];

    if (authState.token) {
        switch (authState.currentUser.nivelAcesso) {
            case AccessLevel.ResponsavelAcao:
                navItems.push({
                    icon: <PlaylistAddCheckIcon />,
                    name: "Ações",
                    link: `/resp-acao/${authState.currentUser.id}`,
                    indent: 0,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Ações",
                    link: `/resp-acao/${authState.currentUser.id}`,
                    indent: 4,
                });
                break;
            case AccessLevel.Sub:
                navItems.push({
                    icon: <ArticleIcon />,
                    name: "Proposições",
                    link: `/sub/${authState.currentUser.id}/proposicao`,
                    indent: 0,
                });
                navItems.push({
                    icon: <NoteAddIcon />,
                    name: "Criar Proposição",
                    link: `/sub/${authState.currentUser.id}/proposicao/novo`,
                    indent: 4,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Proposições",
                    link: `/sub/${authState.currentUser.id}/proposicao`,
                    indent: 4,
                });
                navItems.push({
                    icon: <CheckCircleIcon />,
                    name: "Aprovadas em RD",
                    link: `/sub/${authState.currentUser.id}/proposicao/aprovadas-rd`,
                    indent: 8,
                });
                navItems.push({
                    icon: <VisibilityIcon />,
                    name: "A Revisar",
                    link: `/sub/${authState.currentUser.id}/proposicao/revisao`,
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: `/sub/${authState.currentUser.id}/proposicao/arquivo`,
                    indent: 8,
                });

                navItems.push({
                    icon: <PlaylistAddCheckIcon />,
                    name: "Ações",
                    link: `/sub/${authState.currentUser.id}/acao`,
                    indent: 0,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Ações",
                    link: `/sub/${authState.currentUser.id}/acao`,
                    indent: 4,
                });
                navItems.push({
                    icon: <HourglassBottomIcon />,
                    name: "Em Andamento",
                    link: `/sub/${authState.currentUser.id}/acao/em-andamento`,
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: `/sub/${authState.currentUser.id}/acao/arquivo`,
                    indent: 8,
                });
                break;
            case AccessLevel.Gerente:
                navItems.push({
                    icon: <ArticleIcon />,
                    name: "Proposições",
                    link: `/gerente/${authState.currentUser.id}/proposicao`,
                    indent: 0,
                });
                navItems.push({
                    icon: <NoteAddIcon />,
                    name: "Criar Proposição",
                    link: `/gerente/${authState.currentUser.id}/proposicao/novo`,
                    indent: 4,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Proposições",
                    link: `/gerente/${authState.currentUser.id}/proposicao`,
                    indent: 4,
                });
                navItems.push({
                    icon: <NotificationsActiveIcon />,
                    name: "Novas",
                    link: `/gerente/${authState.currentUser.id}/proposicao/novas`,
                    indent: 8,
                });
                navItems.push({
                    icon: <CheckCircleIcon />,
                    name: "Aprovadas em RD",
                    link: `/gerente/${authState.currentUser.id}/proposicao/aprovadas-rd`,
                    indent: 8,
                });
                navItems.push({
                    icon: <VisibilityIcon />,
                    name: "A Revisar",
                    link: `/gerente/${authState.currentUser.id}/proposicao/revisao`,
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: `/gerente/${authState.currentUser.id}/proposicao/arquivo`,
                    indent: 8,
                });

                navItems.push({
                    icon: <PlaylistAddCheckIcon />,
                    name: "Ações",
                    link: `/gerente/${authState.currentUser.id}/acao`,
                    indent: 0,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Ações",
                    link: `/gerente/${authState.currentUser.id}/acao`,
                    indent: 4,
                });
                navItems.push({
                    icon: <HourglassBottomIcon />,
                    name: "Em Andamento",
                    link: `/gerente/${authState.currentUser.id}/acao/em-andamento`,
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: `/gerente/${authState.currentUser.id}/acao/arquivo`,
                    indent: 8,
                });

                navItems.push({
                    icon: <MeetingRoom />,
                    name: "Gestão de Acessos",
                    link: `/gerente/${authState.currentUser.id}/acessos`,
                    indent: 0,
                });
                break;
            case AccessLevel.AssessorDiretoria:
                navItems.push({
                    icon: <ArticleIcon />,
                    name: "Proposições",
                    link: `/assessor-diretoria/${authState.currentUser.id}/proposicao`,
                    indent: 0,
                });
                navItems.push({
                    icon: <NoteAddIcon />,
                    name: "Criar Proposição",
                    link: `/assessor-diretoria/${authState.currentUser.id}/proposicao/novo`,
                    indent: 4,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Proposições",
                    link: `/assessor-diretoria/${authState.currentUser.id}/proposicao`,
                    indent: 4,
                });
                navItems.push({
                    icon: <Approval />,
                    name: "A Aprovar",
                    link: `/assessor-diretoria/${authState.currentUser.id}/proposicao/aprovacao`,
                    indent: 8,
                });
                navItems.push({
                    icon: <CheckCircleIcon />,
                    name: "Aprovadas em RD",
                    link: `/assessor-diretoria/${authState.currentUser.id}/proposicao/aprovadas-rd`,
                    indent: 8,
                });
                navItems.push({
                    icon: <VisibilityIcon />,
                    name: "A Revisar",
                    link: `/assessor-diretoria/${authState.currentUser.id}/proposicao/revisao`,
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: `/assessor-diretoria/${authState.currentUser.id}/proposicao/arquivo`,
                    indent: 8,
                });

                navItems.push({
                    icon: <PlaylistAddCheckIcon />,
                    name: "Ações",
                    link: `/assessor-diretoria/${authState.currentUser.id}/acao`,
                    indent: 0,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Ações",
                    link: `/assessor-diretoria/${authState.currentUser.id}/acao`,
                    indent: 4,
                });
                navItems.push({
                    icon: <HourglassBottomIcon />,
                    name: "Em Andamento",
                    link: `/assessor-diretoria/${authState.currentUser.id}/acao/em-andamento`,
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: `/assessor-diretoria/${authState.currentUser.id}/acao/arquivo`,
                    indent: 8,
                });

                navItems.push({
                    icon: <Groups />,
                    name: "Reuniões",
                    link: `/assessor-diretoria/${authState.currentUser.id}/reuniao`,
                    indent: 0,
                });

                break;
            case AccessLevel.Diretor:
                navItems.push({
                    icon: <ArticleIcon />,
                    name: "Proposições",
                    link: `/diretoria/${authState.currentUser.id}/proposicao`,
                    indent: 0,
                });
                navItems.push({
                    icon: <NoteAddIcon />,
                    name: "Criar Proposição",
                    link: `/diretoria/${authState.currentUser.id}/proposicao/novo`,
                    indent: 4,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Proposições",
                    link: `/diretoria/${authState.currentUser.id}/proposicao`,
                    indent: 4,
                });
                navItems.push({
                    icon: <Approval />,
                    name: "A Aprovar",
                    link: `/diretoria/${authState.currentUser.id}/proposicao/aprovacao`,
                    indent: 8,
                });
                navItems.push({
                    icon: <CheckCircleIcon />,
                    name: "Aprovadas em RD",
                    link: `/diretoria/${authState.currentUser.id}/proposicao/aprovadas-rd`,
                    indent: 8,
                });
                navItems.push({
                    icon: <VisibilityIcon />,
                    name: "A Revisar",
                    link: `/diretoria/${authState.currentUser.id}/proposicao/revisao`,
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: `/diretoria/${authState.currentUser.id}/proposicao/arquivo`,
                    indent: 8,
                });

                navItems.push({
                    icon: <PlaylistAddCheckIcon />,
                    name: "Ações",
                    link: `/diretoria/${authState.currentUser.id}/acao`,
                    indent: 0,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Ações",
                    link: `/diretoria/${authState.currentUser.id}/acao`,
                    indent: 4,
                });
                navItems.push({
                    icon: <HourglassBottomIcon />,
                    name: "Em Andamento",
                    link: `/diretoria/${authState.currentUser.id}/acao/em-andamento`,
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: `/diretoria/${authState.currentUser.id}/acao/arquivo`,
                    indent: 8,
                });

                navItems.push({
                    icon: <MeetingRoom />,
                    name: "Gestão de Acessos",
                    link: `/diretoria/${authState.currentUser.id}/acessos`,
                    indent: 0,
                });
                break;
            case AccessLevel.Grg:
                navItems.push({
                    icon: <ArticleIcon />,
                    name: "Proposições",
                    link: `/grg/${authState.currentUser.id}/proposicao`,
                    indent: 0,
                });
                navItems.push({
                    icon: <NoteAddIcon />,
                    name: "Criar Proposição",
                    link: `/grg/${authState.currentUser.id}/proposicao/novo`,
                    indent: 4,
                });
                navItems.push({
                    icon: <DensitySmall />,
                    name: "Todas as Proposições",
                    link: `/grg/${authState.currentUser.id}/proposicao`,
                    indent: 4,
                });
                navItems.push({
                    icon: <EventAvailable />,
                    name: "Disponíveis para Inclusão em Pauta",
                    link: `/grg/${authState.currentUser.id}/proposicao/disponiveis`,
                    indent: 8,
                });
                navItems.push({
                    icon: <BookmarkAdded />,
                    name: "Inclusa em Reunião",
                    link: `/grg/${authState.currentUser.id}/proposicao/inclusas-rd`,
                    indent: 8,
                });
                navItems.push({
                    icon: <VisibilityIcon />,
                    name: "A Revisar",
                    link: `/grg/${authState.currentUser.id}/proposicao/revisao`,
                    indent: 8,
                });
                navItems.push({
                    icon: <Approval />,
                    name: "A Aprovar",
                    link: `/grg/${authState.currentUser.id}/proposicao/aprovacao`,
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: `/grg/${authState.currentUser.id}/proposicao/arquivo`,
                    indent: 8,
                });

                navItems.push({
                    icon: <Groups />,
                    name: "Reuniões",
                    link: `/grg/${authState.currentUser.id}/reuniao`,
                    indent: 0,
                });
                navItems.push({
                    icon: <GroupAdd />,
                    name: "Criar Reunião",
                    link: `/grg/${authState.currentUser.id}/reuniao/nova`,
                    indent: 4,
                });
                navItems.push({
                    icon: <PeopleOutline />,
                    name: "Todas as Reuniões",
                    link: `/grg/${authState.currentUser.id}/reuniao`,
                    indent: 4,
                });
                navItems.push({
                    icon: <Today />,
                    name: "Registradas",
                    link: `/grg/${authState.currentUser.id}/reuniao/registradas`,
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: `/grg/${authState.currentUser.id}/reuniao/arquivo`,
                    indent: 8,
                });

                navItems.push({
                    icon: <PlaylistAddCheckIcon />,
                    name: "Ações",
                    link: `/grg/${authState.currentUser.id}/acao`,
                    indent: 0,
                });
                navItems.push({
                    icon: <PlaylistAdd />,
                    name: "Criar Ação",
                    link: `/grg/${authState.currentUser.id}/acao/nova`,
                    indent: 4,
                });
                navItems.push({
                    icon: <List />,
                    name: "Todas as Ações",
                    link: `/grg/${authState.currentUser.id}/acao`,
                    indent: 4,
                });
                navItems.push({
                    icon: <HourglassBottomIcon />,
                    name: "Em Andamento",
                    link: `/grg/${authState.currentUser.id}/acao/em-andamento`,
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: `/grg/${authState.currentUser.id}/acao/arquivo`,
                    indent: 8,
                });

                navItems.push({
                    icon: <MeetingRoom />,
                    name: "Gestão de Acessos",
                    link: `/grg/${authState.currentUser.id}/acessos`,
                    indent: 0,
                });
                break;
            case AccessLevel.SysAdmin:
                navItems.push({
                    icon: <ArticleIcon />,
                    name: "Proposiçõeees",
                    link: "admin/proposicao/",
                    indent: 0,
                });

                navItems.push({
                    icon: <Groups />,
                    name: "Reuniões",
                    link: "admin/reuniao",
                    indent: 0,
                });

                navItems.push({
                    icon: <PlaylistAddCheckIcon />,
                    name: "Ações",
                    link: "admin/acao",
                    indent: 0,
                });

                navItems.push({
                    icon: <MeetingRoom />,
                    name: "Gestão de Acessos",
                    link: "admin/acessos",
                    indent: 0,
                });

                break;
            default:
                break;
        }
        navItems.push({
            icon: <Logout />,
            name: "Logout",
            link: "/logout",
            indent: 0,
        });
    } else {
        navItems.push({
            icon: <LoginIcon />,
            name: "Login",
            link: "/login",
            indent: 0,
        });
    }

    const navHandler = (link: string) => {
        if (link) {
            router.push(link);
        }
    };

    return (
        <React.Fragment>
            {navItems.map((item, index) => (
                <ListItem key={`${item.name}-${index}`} disablePadding>
                    <ListItemButton
                        onClick={() => navHandler(item.link)}
                        sx={{ pl: item.indent }}
                    >
                        <ListItemIcon>{item.icon}</ListItemIcon>
                        <ListItemText primary={item.name} />
                    </ListItemButton>
                </ListItem>
            ))}
        </React.Fragment>
    );
};

export default NavbarItems;
