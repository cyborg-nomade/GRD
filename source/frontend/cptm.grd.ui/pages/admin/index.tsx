import { Button } from "@mui/material";
import { AccessLevel } from "models/common.model";
import { useRouter } from "next/router";
import React from "react";
import { useAuth } from "services/local-storage/auth-hook";
import { useAppSelector } from "services/redux/hooks";

const AdminHome = () => {
    const router = useRouter();
    const { changeLevel } = useAuth();
    const authState = useAppSelector((state) => state.auth);

    const goToSubHandler = () => {
        changeLevel(AccessLevel.Sub);
        router.push(`../sub/${authState.currentUser.id}`);
    };
    const goToGerenteHandler = () => {
        changeLevel(AccessLevel.Gerente);
        router.push(`../gerente/${authState.currentUser.id}`);
    };
    const goToAssessorHandler = () => {
        changeLevel(AccessLevel.AssessorDiretoria);
        router.push(`../assessor-diretoria/${authState.currentUser.id}`);
    };
    const goToDiretoriaHandler = () => {
        changeLevel(AccessLevel.Diretor);
        router.push(`../diretoria/${authState.currentUser.id}`);
    };
    const goToGrgHandler = () => {
        changeLevel(AccessLevel.Grg);
        router.push(`../grg/${authState.currentUser.id}`);
    };

    return (
        <React.Fragment>
            <Button onClick={goToSubHandler}>Sub</Button>
            <Button onClick={goToGerenteHandler}>Gerente</Button>
            <Button onClick={goToAssessorHandler}>Assessor</Button>
            <Button onClick={goToDiretoriaHandler}>Diretoria</Button>
            <Button onClick={goToGrgHandler}>GRG</Button>
        </React.Fragment>
    );
};

export default AdminHome;
