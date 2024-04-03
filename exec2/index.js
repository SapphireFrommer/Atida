const express = require('express');
const router = express.Router();
const app = express();
const path = require('path');
const mongoose = require('mongoose');
const bodyParser = require('body-parser');

const CovidReport = require('./models/covidReport.js');

app.use(bodyParser.json());
app.use('/', router);

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

// Route to show a single report by ID
router.get('/reports/:id', async (req, res) => {
    try {
        console.log('arrived to index.js routing');
        const report = await CovidReport.findById(req.params.id);
        if (!report) {
            return res.status(404).send('Report not found');
        }
        res.render('show.ejs', { report });
    } catch (error) {
        console.error('Error fetching report by ID:', error);
        res.status(500).send('Internal Server Error');
    }
});

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