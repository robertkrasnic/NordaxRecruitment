import React, { useState } from "react";
import { WebApiClient } from "../../common/webApiClient";
import { Input, InputGroup, InputGroupAddon, Label } from "reactstrap";
import { Card, CardImg, CardText, CardBody, CardTitle } from 'reactstrap';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import { Form, FormGroup, FormText, FormFeedback } from 'reactstrap'
import { Col, Row } from 'reactstrap';

import { Button } from '../common/button/Button';
import '../common/button/Button.css'

import { NewLoanApplicationRequest } from "../../models/newLoanApplicationRequest"

import { useLoanApplicationStyles } from "../loan-application/loanApplicationPage.styles"
import { LoanApplicationPage } from "../loan-application/LoanApplicationPage"


export const LoanApplication = () => {
    const apiClient = WebApiClient();
    const [submitError, setSubmitError] = useState<null | string>(null);
    const { buttonStyle, inputStyle } = useLoanApplicationStyles();

    const [loanApplicationData, setLoanApplicationData] = useState({
        loanAmount: 0, personalNumber: "", email: "", lastName: "", phoneNumber: 0, firstName: "", employedSince: 0, employmentType: "", loanDurationYears: 1, monthlyIncome: 0, companyName: ""
    } as NewLoanApplicationRequest)

    const [pageIndex, setPageIndex] = useState(0);
    const setPrevious = () => {
        if (pageIndex > 0)
            setPageIndex(pageIndex - 1)
    }
    const setNext = () => {
        if (pageIndex < pages.length - 1)
            setPageIndex(pageIndex + 1)
    }

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setLoanApplicationData({ ...loanApplicationData, [e.target.name]: e.target.value });
    };

    const onSubmitLoanApplication = () => {
        apiClient.post<{ personalNumber: string }>('api/loan-application', loanApplicationData)
            .then((res) => {
                window.location.href = "/MyPages/" + res;
            }).catch(e => {
                setSubmitError(e.status + " " + e.statusText);
                e.json().then((json: any) => {
                    setSubmitError(e.status + " " + e.statusText + ": " + json);
                });
            });
    }
 
    const pages = [

        <LoanApplicationPage index={0} currentIndex={pageIndex} key={0}>
            <div>
                <Row>
                    <Col>
                        <h1>Loan</h1>
                        <p>Want to hire an acting troupe to recreate the Game of Thrones Red Wedding at your wedding?</p>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <div>
                            <Card>
                                <CardImg top width="100%" src="https://placeholdit.imgix.net/~text?txtsize=33&txt=318%C3%97180&w=318&h=180" alt="Image cap" />
                                <CardBody>
                                    <CardTitle>Private loan</CardTitle>
                                    <CardText>Want to hire an acting troupe to recreate the Game of Thrones Red Wedding at your wedding?</CardText>
                                    <Row className="justify-content-md-center align-items-center" style={{ height: '90%' }}>
                                        <Col className="text-center">
                                            <InputGroup>
                                                <InputGroupAddon addonType="prepend">$</InputGroupAddon>
                                                <Input name={"loanAmount"} placeholder="Amount" type={"number"} step="10000" value={loanApplicationData.loanAmount} onChange={handleChange} />
                                            </InputGroup>
                                        </Col>
                                        <Col className="text-center">
                                            <Button onClick={() => setNext()} >Go for it</Button>
                                        </Col>

                                    </Row>
                                </CardBody>
                            </Card>
                        </div>
                    </Col>
                    <Col>
                        <div>
                            <Card>
                                <CardImg top width="100%" src="https://placeholdit.imgix.net/~text?txtsize=33&txt=318%C3%97180&w=318&h=180" alt="Image cap" />
                                <CardBody>
                                    <CardTitle>Housing loan</CardTitle>
                                    <CardText> Dreamed enough about a house? Sweden or Cannary Islands? <br /> Find out today.</CardText>
                                    <Row className="justify-content-md-center align-items-center" style={{ height: '90%' }}>
                                        <Col className="text-center">
                                                <Input
                                                    name="propertytype"
                                                    id="propertytype"
                                                    type="select">
                                                    <option>
                                                        House
                                                    </option>
                                                    <option>
                                                        Summer house
                                                    </option>
                                                    <option>
                                                        Apartment
                                                    </option>
                                                </Input>
                                        </Col>
                                        <Col className="text-center">
                                            <Button>Apply</Button>
                                        </Col>

                                    </Row>



                                </CardBody>
                            </Card>
                        </div>
                    </Col>

                </Row>
            </div>
        </LoanApplicationPage>,

        <LoanApplicationPage index={1} currentIndex={pageIndex} key={1}>
            <div>
                <div>
                    <Row className="justify-content-md-center align-items-center" style={{ height: '90%' }}>
                        <Col md="5" className="text-center">
                            <p>Personal number</p>
                            <Input style={inputStyle} type={"text"} name={"personalNumber"} placeholder={"Tap to start writing.."} value={loanApplicationData.personalNumber} onChange={handleChange} />
                            <Button style={buttonStyle} onClick={() => setNext()}>Continue</Button>

                        </Col>

                    </Row>
                </div>
            </div>
        </LoanApplicationPage>,

        <LoanApplicationPage index={2} currentIndex={pageIndex} key={2}>

            <Form>
                <Row>
                    <Col>
                        <h4>Loan Info</h4>
                    </Col>
                </Row>
                <Row>
                    <Col md={2}>
                        <FormGroup>
                            <Label for="loanAmount">
                                Loan Amount
                            </Label>
                            <Input id="loanAmount" name={"amount"} placeholder="Amount" type={"number"} step="10000" value={loanApplicationData.loanAmount} onChange={handleChange} />
                        </FormGroup>
                    </Col>

                    <Col md={2}>
                        <FormGroup>

                            <Label for="loanduration">
                                Loan Duration
                            </Label>
                            <Input
                                id="loanduration"
                                type="select">
                                <option>
                                    1
                                </option>
                                <option>
                                    2
                                </option>
                                <option>
                                    3
                                </option>
                                <option>
                                    4
                                </option>
                                <option>
                                    5
                                </option>
                                <option>
                                    6
                                </option>
                                <option>
                                    7
                                </option>
                                <option>
                                    8
                                </option>
                                <option>
                                    9
                                </option>
                                <option>
                                    10
                                </option>
                            </Input>


                        </FormGroup>
                    </Col>
                </Row>


                <Row>
                    <Col>
                        <h4>Personal Info</h4>
                    </Col>
                </Row>
                <Row>
                    <Col md={6}>
                        <FormGroup>
                            <Label for="personalnumber">
                                Personal Number
                            </Label>
                            <Input disabled={true} id="personalnumber" type={"number"} name={"personalNumber"} placeholder={"Tap to start writing.."} value={loanApplicationData.personalNumber} onChange={handleChange} /> 
                        </FormGroup>
                    </Col>
                </Row>
                <Row>
                    <Col md={6}>
                        <FormGroup>
                            <Label for="firstname">
                                First Name
                            </Label>
                            <Input id="firstname" type={"text"} name={"firstName"} placeholder={"Tap to start writing.."} value={loanApplicationData.firstName} onChange={handleChange} />
                        </FormGroup>
                    </Col>
                    <Col md={6}>
                        <FormGroup>
                            <Label for="lastname">
                                Last Name
                            </Label>
                            <Input id="lastname" type={"text"} name={"lastName"} placeholder={"Tap to start writing.."} value={loanApplicationData.lastName} onChange={handleChange} />
                        </FormGroup>
                    </Col>
                </Row>
                <Row>
                    <Col md={6}>
                        <FormGroup>
                            <Label for="phonenumber">
                                Phone Number
                            </Label>
                            <Input id="phonenumber" type={"number"} name={"phoneNumber"} placeholder={"Tap to start writing.."} value={loanApplicationData.phoneNumber} onChange={handleChange} />
                        </FormGroup>
                    </Col>
                    <Col md={6}>
                        <FormGroup>
                            <Label for="email">
                                Email
                            </Label>
                            <Input id="email" type={"email"} name={"email"} placeholder={"Tap to start writing.."} value={loanApplicationData.email} onChange={handleChange} />
                        </FormGroup>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <h4>Economy Info</h4>
                    </Col>
                </Row>
                <Row>
                    <Col md={6}>
                        <FormGroup>

                            <Label for="monthlyincome">
                                Monthly Income <small>(before tax)</small>
                            </Label>
                            <InputGroup>
                                <Input id="monthlyincome" type={"number"} name={"monthlyIncome"} placeholder={"Tap to start writing.."} value={loanApplicationData.monthlyIncome} onChange={handleChange} />
                                <InputGroupAddon addonType="append">kr</InputGroupAddon>
                            </InputGroup>
                        </FormGroup>
                    </Col>
                </Row>
                <Row>
                    <Col md={6}>
                        <FormGroup>
                            <Label for="companyname">
                                Comapny Name
                            </Label>
                            <Input id="companyname" type={"text"} name={"companyName"} placeholder={"Tap to start writing.."} value={loanApplicationData.companyName} onChange={handleChange} />
                        </FormGroup>
                    </Col>
                    <Col md={4}>
                        <FormGroup>
                            <Label for="employmenttype">
                                Employment Type
                            </Label>
                            <Input id="employmenttype" type={"text"} name={"employmentType"} placeholder={"Tap to start writing.."} value={loanApplicationData.employmentType} onChange={handleChange} />
                        </FormGroup>
                    </Col>
                    <Col md={2}>
                        <FormGroup>

                            <Label for="employedsince">
                                Employmed Since
                            </Label>
                            <Input id="employedsince" type={"select"} name={"employeedSince"} placeholder={"Tap to start writing.."} value={loanApplicationData.employedSince} onChange={handleChange}>
                                <option>
                                    2021
                                </option>
                                <option>
                                    2020
                                </option>
                                <option>
                                    2019
                                </option>
                                <option>
                                    before 2019 
                                </option>
                            </Input>


                        </FormGroup>
                    </Col>
                </Row>
                
                <FormGroup>
                    <Label for="exampleFile">
                        Last 3 payslips
                    </Label>
                    <FormText>
                        This is some placeholder block-level help text for the above input. It is a bit lighter and easily wraps to a new line.
                    </FormText>
                    <Input id="exampleFile" type={"file"} name={"file1"} placeholder={"Tap to start writing.."} onChange={handleChange} />
                    <Input id="exampleFile" type={"file"} name={"file2"} placeholder={"Tap to start writing.."} onChange={handleChange} />
                    <Input id="exampleFile" type={"file"} name={"file3"} placeholder={"Tap to start writing.."} onChange={handleChange} />
                </FormGroup>




            </Form>
            <Button onClick={() => onSubmitLoanApplication()}>
                Submit application
            </Button>

        </LoanApplicationPage>
    ];



    return (
        <div style={{ height: '100%', position: 'relative' }}>
            {pages}
            {pageIndex > 0 && pageIndex < 3 ?
                <div style={{ position: "absolute", bottom: "22px", left: "50%" }}>
                    <Button style={{ position: "relative", left: "-50%", width: "125px" }} color={"gray"} onClick={() => setPrevious()}>Go Back</Button>
                </div>
                : null}
            
        </div>
    );
};