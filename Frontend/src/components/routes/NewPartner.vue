<script setup>
import { addPartner } from '@/scripts/api/partner/partner';
import { Partner } from '@/scripts/api/partner/partner-model';
import { reactive, ref } from 'vue';
import { useRouter } from 'vue-router';

const api = "https://localhost:7079";

const router = useRouter();

const currentDate = new Date();
const form = reactive(new Partner('', '', '', '', '', 0, currentDate.toISOString(), '', false, '', null))
const errors = ref({
    firstName: false,
    lastName: false,
    croatianPin: false,
    partnerTypeId: false,
    createdByUser: false,
    externalCode: false,
    gender: false
})

function resetErrors(){
    errors.value.firstName = false;
    errors.value.lastName = false;
    errors.value.croatianPin = false;
    errors.value.partnerTypeId = false;
    errors.value.createdByUser = false;
    errors.value.externalCode = false;
    errors.value.gender = false;
}

async function onSuccess(){
    var added = await addPartner(api, form);
    console.log(added)

    if(added) router.push({ path: "/new/" + added.data.partnerNumber});
}

function submitForm() {
    var submit = true;
    resetErrors();

    if(form.firstName.length == 0){
        submit = false;
        errors.value.firstName = true;
    }

    if(form.firstName.length == 0){
        submit = false;
        errors.value.lastName = true;
    }

    if(form.croatianPin.length > 0){
        if(form.croatianPin.length != 11){
            submit = false;
            errors.value.croatianPin = true;
        }
    }

    if(!form.partnerTypeId){
        submit = false;
        errors.value.partnerTypeId = true;
    }

    if(form.createdByUser.length == 0 || !form.createdByUser.includes("@")){
        submit = false;
        errors.value.createdByUser = true;
    }

    if(form.externalCode.length > 0){
        if(form.externalCode.length < 10 || form.externalCode.length > 20){
            submit = false;
            errors.value.externalCode = true;
        }
    }

    if(!form.gender){
        submit = false;
        errors.value.gender = true;
    }

    if(submit){
        onSuccess();
    }
    return submit;
}

function back(){
    router.back();
}

</script>

<template>
    <div class="w-100 d-flex flex-column justify-content-center align-items-center add-form">
        <div class="w-100 d-flex justify-content-left align-items-center p-3">
            <button @click="back" class="btn btn-secondary">Back</button>
        </div>
        <div>
            <form @submit.prevent="submitForm">
                <div class="row">
                    <div class="col">
                        <div id="fname-div">
                            <label for="fname">First name:</label>
                            <input type="text" id="fname" name="fname" v-model.trim="form.firstName" class="form-control">
                            <span v-show="errors.firstName" class="error-msg">First name cannot be empty.</span>
                        </div>
                    </div>
                    <div class="col">
                        <div id="lname-div">
                            <label for="lname">Last name:</label>
                            <input type="text" id="lname" name="lname" v-model.trim="form.lastName" class="form-control">
                            <span v-show="errors.lastName" class="error-msg">Last name cannot be empty.</span>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <div id="address-div">
                            <label for="address">Address:</label>
                            <input type="text" id="address" name="address" v-model.trim="form.address" class="form-control">
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <div id="gender-div">
                            <label>Gender:</label><br>
                            <div class="form-check">
                                <input type="radio" id="gender1" name="gender" value="M" v-model="form.gender" class="form-check-input">
                                <label for="gender1" class="form-check-label">M</label>
                            </div>
                            <div class="form-check">
                                <input type="radio" id="gender2" name="gender" value="F" v-model="form.gender" class="form-check-input">
                                <label for="gender2" class="form-check-label">F</label>
                            </div>
                            <div class="form-check">
                                <input type="radio" id="gender3" name="gender" value="N" v-model="form.gender" class="form-check-input">
                                <label for="gender3" class="form-check-label">N</label>
                            </div>
                            <span v-show="errors.gender" class="error-msg">Gender must be selected.</span>
                        </div>
                    </div>
                </div>

                <div id="cpin-div">
                    <label for="cpin">Croatian pin:</label>
                    <input type="text" id="cpin" name="cpin" v-model.trim="form.croatianPin" class="form-control">
                    <span v-show="errors.croatianPin" class="error-msg">Invalid Croatian pin.</span>
                </div>
                <br>

                <div id="ptype-div">
                    <label>Partner type:</label><br>
                    <div class="form-check">
                        <input type="radio" id="ptype1" name="ptype" :value="1" v-model="form.partnerTypeId" class="form-check-input">
                        <label for="ptype1" class="form-check-label">Personal</label>
                    </div>
                    <div class="form-check">
                        <input type="radio" id="ptype2" name="ptype" :value="2" v-model="form.partnerTypeId" class="form-check-input">
                        <label for="ptype2" class="form-check-label">Legal</label>
                    </div>
                    <span v-show="errors.partnerTypeId" class="error-msg">Partner type must be selected.</span>
                </div>

                <div id="user-div">
                    <label for="user">User:</label>
                    <input type="email" id="user" name="user" v-model="form.createdByUser" class="form-control">
                    <span v-show="errors.createdByUser" class="error-msg">User is invalid.</span>
                </div>

                <div id="foreign-div">
                    <div class="form-check">
                        <input type="checkbox" id="foreign" name="foreign" v-model="form.isForeign" class="form-check-input">
                        <label for="foreign" class="form-check-label">Is foreign</label>
                    </div>
                </div>

                <div id="ecode-div">
                    <label for="ecode">External code:</label>
                    <input type="text" id="ecode" name="ecode" v-model.trim="form.externalCode" class="form-control">
                    <span v-show="errors.externalCode" class="error-msg">External code must be between 10 and 20 characters long.</span>
                </div>

                <div class="w-100 d-flex justify-content-center align-items-center p-3">
                    <input type="submit" value="Submit" class="btn btn-primary">
                </div>
            </form>
        </div>
    </div>
</template>

<style>
.error-msg{
    color: red;
}
.add-form{
    background-color: rgb(236, 236, 236);
    border-radius: 20px;
}
</style>