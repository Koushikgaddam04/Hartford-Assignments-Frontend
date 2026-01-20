const express = require('express');
const axios = require('axios');
const app = express();
const PORT = 3000;

// Middleware to parse JSON bodies
app.use(express.json());
app.use(express.static('public'));

// Local "Database"
let posts = [];

// 1. Initial Fetch: Get data from the external API and store it in our array
const initializeData = async () => {
  try {
    const response = await axios.get('https://jsonplaceholder.typicode.com/posts?_limit=5');
    posts = response.data;
    console.log("✅ Data synced to local array.");
  } catch (error) {
    console.error("Error fetching initial data:", error.message);
  }
};

// 2. GET all posts from the array
app.get('/display', (req, res) => {
  res.json(posts)
  console.log(posts.length);
});

// 3. POST a new document into the array
app.post('/newpost', (req, res) => {
    // console.log(req.body.title);
    const newPost = {
        id: posts.length > 0 ? Math.max(...posts.map(p => p.id)) + 1 : 1,
        title : req.body.title,
        body : req.body.body,
        userId: req.body.userId
    };
    console.log(newPost);

    posts.push(newPost);
    console.log(`Added post: ${newPost.title}. Total: ${posts.length}`);
    res.status(201).json(newPost);
});

app.put('/update', (req, res)=>{
  let objId = 6;
  for(let i in posts){
    if(posts[i].id == objId){
      posts[i].title = "Updated Title";
      posts[i].body = "Updated content";
    }
  }
  res.status(201).json(posts);
});

app.delete('/delete/:id', (req, res)=>{
  let postid=req.params.id;
  posts = posts.filter(ele=>ele.id != postid) ;
  console.log(posts)
  res.status(201).json(posts);
});



app.listen(PORT, () => {
    console.log(`Server running at http://localhost:${PORT}`);
    initializeData();
});

