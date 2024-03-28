const mongoose = require('mongoose');

const singleVaccineSchema = new mongoose.Schema({
    date: Date,
    manuf: String
})

const covidReportSchema = new mongoose.Schema({
    first_name: {
        type: String,
        required: true
    },
    last_name: {
        type: String,
        required: true
    },
    id_num: {
        type: Number,
        required: true,
        min: 0
    },
    birth_date: {
        type: Date
    },
    city: String,
    street: String,
    house_num: {
        type: Number,
        min: 1
    },
    house_phone: {
        type: String
    },
    cellphone: {
        type: String
    },
    sick_start: {
        type: Date
    },
    sick_end: {
        type: Date
    }
    vaccines: {
        type: [singleVaccineSchema]
    }
    
})

const CovidReport = mongoose.model('CovidRepoort', covidReportSchema);

module.exports = CovidReport;