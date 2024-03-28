const mongoose = require('mongoose');
const CovidReport = require('./covidReport.js');

mongoose.connect('mongodb://localhost:27017/report',{useNewUrlParser: true, useUnifiedTopology: true})
.then(() => {
    console.log("connection open")
})
.catch(err => {
    console.log("oh no error")
    console.log(err)
})

const p = new CovidReport({
    name: 'Steven',
    id: 352466,
    category: 'fruit'
})

p.save().then(p => {
    console.log(p)
})
.catch(e => {
    console.log(e)
})