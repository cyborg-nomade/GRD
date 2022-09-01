import React from "react";
import ConfirmationModalView from "./ConfirmationModalView";

const ConfirmationModalContainer = (props: {
    open: boolean;
    handleClose: () => void;
    title: string;
    children?: React.ReactNode;
    disagreeHandler: () => void;
    agreeHandler: () => void;
}) => {
    return <ConfirmationModalView {...props} />;
};

export default ConfirmationModalContainer;
