import React, { useEffect, useState } from "react";
import { WebApiClient } from "../../common/webApiClient";

import { Col, Row } from 'reactstrap';

import { PersonalInformation } from "../../models/loanApplicationResponse"
import { LoanApplications } from "../../models/loanApplicationResponse"
import { RouteComponentProps } from "react-router-dom";



export const MyPages = (props: RouteComponentProps<{ personalNumber: string }>) => {

    const apiClient = WebApiClient(); 
    const [loadError, setLoadError] = useState<null | string>(null);
    const [loanApplications, setLoanApplications] = useState<LoanApplications[]>([]);
    const [personalInformation, setPersonalInformation] = useState<PersonalInformation>();

    useEffect(() => {
        loadLoanApplicationModel();
    }, []);

    const loadLoanApplicationModel = () => {
        apiClient.get<{ loanApplications: LoanApplications[], personalInformation: PersonalInformation }>('api/loan-application/' + props.match.params.personalNumber)
            .then((res) => {

                setLoanApplications(res.loanApplications);
                setPersonalInformation(res.personalInformation);

            }).catch(e => {
                setLoadError(e.status + " " + e.statusText);
                e.json().then((json: any) => {

                    setLoadError(e.status + " " + e.statusText + ": " + json);
                    alert(loadError);

                });
            });
    }


    const loanItems = loanApplications.map((loan) =>
        <div>
            <Row>
                <h6 key={loan.id}>Loan id: {loan.id}</h6>
            </Row>
            
            <Row>
                <Col>
                    <p>Loan Amount</p>
                </Col>
                <Col>
                    {loan.amount}
                </Col>
            </Row>
            <Row>
                <Col>
                    <p>Loan duration: </p>
                </Col>
                <Col>
                    {loan.durationYears}
                </Col>
            </Row>
            <Row>
                <Col>
                    <p>Loan type: </p>
                </Col>
                <Col>
                    {loan.loanType}
                </Col>
            </Row>

        </div>)
    
    
    const userInfo = (
        <div>
            <Row>
                <Col>
                    <p>First Name: </p>
                </Col>
                <Col>
                    { personalInformation?.firstName }
                </Col>
            </Row>
            <Row>
                <Col>
                    <p>Last Name: </p>
                </Col>
                <Col>
                    {personalInformation?.lastName}
                </Col>
            </Row>
            <Row>
                <Col>
                    <p>Email: </p>
                </Col>
                <Col>
                    {personalInformation?.email}
                </Col>
            </Row>
            <Row>
                <Col>
                    <p>Personal Number: </p>
                </Col>
                <Col>
                    {personalInformation?.personalNumber}
                </Col>
            </Row>
            <Row>
                <Col>
                    <p>Personal Number: </p>
                </Col>
                <Col>
                    {personalInformation?.phoneNumber}
                </Col>
            </Row>
        </div>
    );

    return (
        <div style={{ height: '100%', position: 'relative' }}>
            <Row>
                <h4>Personal Information</h4>
            </Row>
            {userInfo}


            <Row>
                <h4>Ongoing Loan Applications</h4>
            </Row>
            {loanItems}

            
        </div>
    );
};