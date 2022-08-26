import React from "react";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { ProposicaoListDto } from "models/proposicoes/proposicao.model";
import { keys } from "lodash";
import ListPaper from "../ListPaper";

const ProposicaoListView = (props: { rows: ProposicaoListDto[] }) => {
    const fields = keys(new ProposicaoListDto());
    const cols: GridColDef[] = fields.map((field) => {
        return {
            field: field,
            width: 150,
            headerName: field
                .replace(/([A-Z])/g, " $1")
                .replace(/^./, function (str) {
                    return str.toUpperCase();
                }),
        };
    });

    return (
        <ListPaper>
            <DataGrid rows={props.rows} columns={cols} />
        </ListPaper>
    );
};

export default ProposicaoListView;
