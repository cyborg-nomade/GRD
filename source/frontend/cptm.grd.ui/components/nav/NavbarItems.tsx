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
    ManageAccounts,
    MeetingRoom,
    PeopleOutline,
    PlaylistAdd,
    Today,
    List,
    People,
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
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Ações",
                    link: "",
                    indent: 4,
                });
                break;
            case AccessLevel.Sub:
                navItems.push({
                    icon: <ArticleIcon />,
                    name: "Proposições",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <NoteAddIcon />,
                    name: "Criar Proposição",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Proposições",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <CheckCircleIcon />,
                    name: "Aprovadas em RD",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <VisibilityIcon />,
                    name: "A Revisar",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: "",
                    indent: 8,
                });

                navItems.push({
                    icon: <PlaylistAddCheckIcon />,
                    name: "Ações",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Ações",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <HourglassBottomIcon />,
                    name: "Em Andamento",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: "",
                    indent: 8,
                });
                break;
            case AccessLevel.Gerente:
                navItems.push({
                    icon: <ArticleIcon />,
                    name: "Proposições",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <NoteAddIcon />,
                    name: "Criar Proposição",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Proposições",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <NotificationsActiveIcon />,
                    name: "Novas",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <CheckCircleIcon />,
                    name: "Aprovadas em RD",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <VisibilityIcon />,
                    name: "A Revisar",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: "",
                    indent: 8,
                });

                navItems.push({
                    icon: <PlaylistAddCheckIcon />,
                    name: "Ações",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Ações",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <HourglassBottomIcon />,
                    name: "Em Andamento",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: "",
                    indent: 8,
                });

                navItems.push({
                    icon: <MeetingRoom />,
                    name: "Gestão de Acessos",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <ManageAccounts />,
                    name: "Gerir Subordinados",
                    link: "",
                    indent: 4,
                });
                break;
            case AccessLevel.AssessorDiretoria:
                navItems.push({
                    icon: <ArticleIcon />,
                    name: "Proposições",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <NoteAddIcon />,
                    name: "Criar Proposição",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Proposições",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <Approval />,
                    name: "A Aprovar",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <CheckCircleIcon />,
                    name: "Aprovadas em RD",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <VisibilityIcon />,
                    name: "A Revisar",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: "",
                    indent: 8,
                });

                navItems.push({
                    icon: <PlaylistAddCheckIcon />,
                    name: "Ações",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Ações",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <HourglassBottomIcon />,
                    name: "Em Andamento",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: "",
                    indent: 8,
                });

                navItems.push({
                    icon: <Groups />,
                    name: "Reuniões",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <PeopleOutline />,
                    name: "Apresentação Prévia",
                    link: "",
                    indent: 4,
                });

                break;
            case AccessLevel.Diretor:
                navItems.push({
                    icon: <ArticleIcon />,
                    name: "Proposições",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <NoteAddIcon />,
                    name: "Criar Proposição",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Proposições",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <Approval />,
                    name: "A Aprovar",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <CheckCircleIcon />,
                    name: "Aprovadas em RD",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <VisibilityIcon />,
                    name: "A Revisar",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: "",
                    indent: 8,
                });

                navItems.push({
                    icon: <PlaylistAddCheckIcon />,
                    name: "Ações",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <PersonIcon />,
                    name: "Minhas Ações",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <HourglassBottomIcon />,
                    name: "Em Andamento",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: "",
                    indent: 8,
                });

                navItems.push({
                    icon: <MeetingRoom />,
                    name: "Gestão de Acessos",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <ManageAccounts />,
                    name: "Gerir Subordinados",
                    link: "",
                    indent: 4,
                });
                break;
            case AccessLevel.Grg:
                navItems.push({
                    icon: <ArticleIcon />,
                    name: "Proposições",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <NoteAddIcon />,
                    name: "Criar Proposição",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <DensitySmall />,
                    name: "Todas as Proposições",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <EventAvailable />,
                    name: "Disponíveis para Inclusão em Pauta",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <BookmarkAdded />,
                    name: "Inclusa em Reunião",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <VisibilityIcon />,
                    name: "A Revisar",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <Approval />,
                    name: "A Aprovar",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: "",
                    indent: 8,
                });

                navItems.push({
                    icon: <Groups />,
                    name: "Reuniões",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <GroupAdd />,
                    name: "Criar Reunião",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <PeopleOutline />,
                    name: "Todas as Reuniões",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <Today />,
                    name: "Registradas",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: "",
                    indent: 8,
                });

                navItems.push({
                    icon: <PlaylistAddCheckIcon />,
                    name: "Ações",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <PlaylistAdd />,
                    name: "Criar Ação",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <List />,
                    name: "Todas as Ações",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <HourglassBottomIcon />,
                    name: "Em Andamento",
                    link: "",
                    indent: 8,
                });
                navItems.push({
                    icon: <InventoryIcon />,
                    name: "Arquivadas",
                    link: "",
                    indent: 8,
                });

                navItems.push({
                    icon: <MeetingRoom />,
                    name: "Gestão de Acessos",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <ManageAccounts />,
                    name: "Gerir Usuários do Sistema",
                    link: "",
                    indent: 4,
                });
                break;
            case AccessLevel.SysAdmin:
                navItems.push({
                    icon: <People />,
                    name: "Sub",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <People />,
                    name: "Gerente",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <People />,
                    name: "Acessor",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <People />,
                    name: "Diretor",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <People />,
                    name: "GRG",
                    link: "",
                    indent: 0,
                });

                navItems.push({
                    icon: <ArticleIcon />,
                    name: "Proposições",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <NoteAddIcon />,
                    name: "Criar Proposição",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <DensitySmall />,
                    name: "Todas as Proposições",
                    link: "",
                    indent: 4,
                });

                navItems.push({
                    icon: <Groups />,
                    name: "Reuniões",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <GroupAdd />,
                    name: "Criar Reunião",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <PeopleOutline />,
                    name: "Todas as Reuniões",
                    link: "",
                    indent: 4,
                });

                navItems.push({
                    icon: <PlaylistAddCheckIcon />,
                    name: "Ações",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <PlaylistAdd />,
                    name: "Criar Ação",
                    link: "",
                    indent: 4,
                });
                navItems.push({
                    icon: <List />,
                    name: "Todas as Ações",
                    link: "",
                    indent: 4,
                });

                navItems.push({
                    icon: <MeetingRoom />,
                    name: "Gestão de Acessos",
                    link: "",
                    indent: 0,
                });
                navItems.push({
                    icon: <ManageAccounts />,
                    name: "Gerir Usuários do Sistema",
                    link: "",
                    indent: 4,
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
