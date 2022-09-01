import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Divider from "@mui/material/Divider";
import Drawer from "@mui/material/Drawer";
import IconButton from "@mui/material/IconButton";
import List from "@mui/material/List";
import MenuIcon from "@mui/icons-material/Menu";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import NavbarItems from "./NavbarItems";
import { useRouter } from "next/router";

const drawerWidth = 300;

const NavbarView = (props: React.PropsWithChildren) => {
    const [mobileOpen, setMobileOpen] = React.useState(false);
    const router = useRouter();

    const handleDrawerToggle = () => {
        setMobileOpen(!mobileOpen);
    };

    const drawer = (
        <Box onClick={handleDrawerToggle} sx={{ textAlign: "center" }}>
            <Typography variant="h6" sx={{ my: 2 }}>
                GRD
            </Typography>
            <Divider />
            <List>
                <NavbarItems />
            </List>
        </Box>
    );

    const container =
        typeof window !== undefined ? () => window.document.body : undefined;

    return (
        <Box sx={{ display: "flex" }}>
            <AppBar component="nav">
                <Toolbar>
                    <Typography
                        variant="h6"
                        component="div"
                        sx={{
                            flexGrow: 1,
                            display: { xs: "block", lg: "none" },
                            cursor: "pointer",
                        }}
                        onClick={() => {
                            router.push("../");
                        }}
                    >
                        GRD
                    </Typography>
                    <Typography
                        variant="h6"
                        component="div"
                        sx={{
                            flexGrow: 1,
                            display: { xs: "none", lg: "block" },
                            cursor: "pointer",
                        }}
                        onClick={() => {
                            router.push("../");
                        }}
                    >
                        GRD - Sistema de Gestão de Reuniões de Diretoria
                    </Typography>
                    <IconButton
                        color="inherit"
                        aria-label="open drawer"
                        edge="start"
                        onClick={handleDrawerToggle}
                        sx={{ ml: 2 }}
                    >
                        <MenuIcon />
                    </IconButton>
                </Toolbar>
            </AppBar>
            <Box component="nav">
                <Drawer
                    anchor="right"
                    container={container}
                    variant="temporary"
                    open={mobileOpen}
                    onClose={handleDrawerToggle}
                    ModalProps={{
                        keepMounted: true, // Better open performance on mobile.
                    }}
                    sx={{
                        display: { xs: "block" },
                        "& .MuiDrawer-paper": {
                            boxSizing: "border-box",
                            width: drawerWidth,
                        },
                    }}
                >
                    {drawer}
                </Drawer>
            </Box>

            <Box component="main" sx={{ width: "100%" }}>
                {props.children}
            </Box>
        </Box>
    );
};

export default NavbarView;
