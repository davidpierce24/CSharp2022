// $(document).ready(() => {

//     $("#btn").on("click", function (e){
//         e.preventDefault();
//         $.ajax({
//             url: "passcode",
//             success: function(){
//                 console.log("success")
//                 $('#count').html(`<h2>${sessionStorage.getItem("Count")}</h2> `)
//                 sessionStorage.getItem("Count")
//             }, 
//             error: function(err){
//                 console.log(err)
//             }
//         })

//     })

// })


// async function call() {
//     const result = await fetch ("http://localhost:5006/passcode");
//     const messageResult = await result.json();
//     // message.innerHTML = messageResult;
//     updateStats();
//     checkWin();
// }
