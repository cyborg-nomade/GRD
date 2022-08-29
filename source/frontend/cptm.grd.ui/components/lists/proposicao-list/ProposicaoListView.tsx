import React from "react";
import {
    DataGrid,
    GridColDef,
    GridEventListener,
    GridToolbar,
} from "@mui/x-data-grid";
import { ProposicaoListDto } from "models/proposicoes/proposicao.model";
import { keys } from "lodash";
import ListPaper from "../ListPaper";
import {
    ObjetoProposicaoView,
    ProposicaoStatusView,
    ReceitaDespesaView,
} from "models/common.model";
import { useRouter } from "next/router";

const ProposicaoListView = (props: {
    rows: ProposicaoListDto[];
    isLoading: boolean;
}) => {
    const fields = keys(new ProposicaoListDto()).filter((key) => {
        return key != "criador" && key != "areaSolicitante" && key != "id";
    });
    const cols: GridColDef[] = fields.map((field) => {
        return {
            field: field,
            width:
                field === "idPrd"
                    ? 70
                    : field === "status"
                    ? 250
                    : field === "moeda"
                    ? 80
                    : field === "valorTotalProposicao"
                    ? 160
                    : 140,
            headerName: field
                .replace(/([A-Z])/g, " $1")
                .replace(/^./, function (str) {
                    return str.toUpperCase();
                }),
        };
    });
    const rows = props.rows.map((proposicao) => {
        return {
            ...proposicao,
            objeto: ObjetoProposicaoView.find(
                (o) => o.value === proposicao.objeto
            )?.label,
            receitaDespesa: ReceitaDespesaView.find(
                (o) => o.value === proposicao.receitaDespesa
            )?.label,
            status: ProposicaoStatusView.find(
                (o) => o.value === proposicao.status
            )?.label,
        };
    });

    const router = useRouter();

    const handleRowClick: GridEventListener<"rowClick"> = (params) => {
        console.log(params);
        router.push(`${router.asPath}/proposicao/${params.id}`);
    };

    return (
        <ListPaper>
            <DataGrid
                autoHeight
                rows={rows}
                columns={cols}
                rowsPerPageOptions={[5, 10, 20]}
                initialState={{
                    pagination: {
                        pageSize: 5,
                    },
                }}
                disableSelectionOnClick
                components={{ Toolbar: GridToolbar }}
                loading={props.isLoading}
                onRowClick={handleRowClick}
            />
        </ListPaper>
    );
};

export default ProposicaoListView;
