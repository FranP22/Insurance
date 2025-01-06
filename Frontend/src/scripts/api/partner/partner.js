import { Partner } from "./partner-model";
//const config = require('dotenv').config({ path: './config.env' });
import axios from "axios";
//const axios = require('axios').default;

export async function getAllPartners(address){
    try {
        var response = await axios.get(address + '/api/Partner');
        return response;
    }
    catch(error){
        return error;
    }
}

export async function getPartnerByNumber(address, number){
    try {
        var response = await axios.get(address + '/api/Partner/' + number);
        return response;
    }
    catch(error){
        return error;
    }
}

export async function getPartnerPolicies(address, number){
    try {
        var response = await axios.get(address + '/api/Partner/' + number + '/Policies');
        return response;
    }
    catch(error){
        return error;
    }
}

export async function addPartner(address, partner){
    try {
        var response = await axios.post(address + '/api/Partner', partner);
        console.log(response)
        return response;
    }
    catch(error){
        return error;
    }
}