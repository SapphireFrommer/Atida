const express = require('express');
const app = express();
const path = require('path');
const mongoose = require('mongoose');

const CovidReport = require('./models/covidReport.js');

mongoose.connect('mongodb://localhost:27017/report',{useNewUrlParser: true, useUnifiedTopology: true})
.then(() => {
    console.log("connection open")
})
.catch(err => {
    console.log("oh no error")
    console.log(err)
})

app.set('views', path.join(__dirname, 'views/reports/'));
app.set('view engine', 'ejs');
app.use(express.urlencoded({extended: true}))
//app.use(methodOverride('_method'))

app.get('/reports', async (req, res) => {
    console.log('reports')
    const reports = await CovidReport.find({});
    res.render('index.ejs',{reports});
})

app.get('/reports/new', (req, res) => {
    console.log('reports - new')
    res.render('new.ejs');
})

app.get('/', (req, res) => {
    console.log('main');
})

app.post('/reports', async (req, res) => {
    const newReport = new CovidReport(req.body);
    await newReport.save();
    console.log(newReport);
    res.send('accepted your report')
})

//for debugging - delete
app.delete('reports/:id', async (req, res) => {
    const {id} = req.params;
    const deletedReport = await CovidReport.findByIdAndDelete(id);
    res.redirect('/reports');
})
app.listen(3000, () => {
    console.log("app is listening on port 3000");
})