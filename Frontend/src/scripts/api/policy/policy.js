import { Policy } from "./policy-model";
import axios from "axios";
//const axios = require('axios').default;

export async function getAllPolicies(address){
    try {
        var response = await axios.get(address + '/api/Policy');
        return response;
    }
    catch(error){
        return error;
    }
}

export async function getPolicyByNumber(address, number){
    try {
        var response = await axios.get(address + '/api/Policy/' + number);
        return response;
    }
    catch(error){
        return error;
    }
}

export async function addPolicy(address, policy){
    try {
        var response = await axios.post(address + '/api/Policy', policy);
        return response;
    }
    catch(error){
        return error;
    }
}