import React from "react";
import { useLoanApplicationStyles } from "./loanApplicationPage.styles";
import '../signUp/surveyPageAnimation.css';
import {Col, Row} from "reactstrap";

export const LoanApplicationPage = (props: React.PropsWithChildren<{index: number, currentIndex: number}>) => {
    const { containerStyle } = useLoanApplicationStyles();



    const relevantStyle = props.currentIndex < props.index ? "hiddenBotStyle" : props.currentIndex > props.index ? "hiddenTopStyle" : "visibleStyle";

    return (
        <div className={relevantStyle} style={containerStyle}>
            <div style={{position: 'relative', width: '100%', height: '100%'}}>
                <Row className="justify-content-lg-center align-items-center" style={{height: "100%", padding: "0 15px"}}>
                    <Col style={{margin: '0 auto'}} className="text-left">
                        {props.children}
                    </Col>
                </Row>
            </div>
        </div>
    );
};
