// [HttpPost("create")]
//         public IActionResult Create(VGPerson vuser)
//         {
//             if(ModelState.IsValid)
//             {
//                 PasswordHasher<VGPerson> hasher = new PasswordHasher<VGPerson>();
//                 vuser.password = hasher.HashPassword(vuser,vuser.password);
//                 Person user = new Person
//                 {
                   
//                     first_name = vuser.first_name,
//                     last_name = vuser.last_name,
//                     email = vuser.email,
//                     password = vuser.password
//                 };
//                 _bcontext.users.Add(user);
//                 return RedirectToAction("Login");
                
//             }
//             return View("Index",vuser);
//         }
//         [HttpGet("login")]
//         public IActionResult Login()
//         {
//             return View();
//         }
//         [HttpPost("log_in")]
//         public IActionResult Log(VLPerson vuser)
//         {
//             if(ModelState.IsValid)
//             {
//                 Person checkemail = _bcontext.users.SingleOrDefault(user =>user.email == vuser.email);
//                 if(checkemail != null)
//                 {
//                     PasswordHasher<VLPerson> hasher = new PasswordHasher<VLPerson>();
//                     if(hasher.VerifyHashedPassword(vuser,checkemail.password,vuser.password) != PasswordVerificationResult.Failed)
//                     {
//                          HttpContext.Session.SetInt32("log_id",checkemail.user_id);
//                          return View("Account", new{id = checkemail.user_id});
//                     }
//                     else
//                     {
//                         ModelState.AddModelError("password","Wrong password !");
//                         return RedirectToAction("Login",vuser);
//                     }
                   
//                 }
//                 else{
//                     ModelState.AddModelError("email","User does not exit !");
//                     return RedirectToAction("Login",vuser);
//                 }

//             }
//             return RedirectToAction("Login",vuser);
//         }
//         [HttpGet("acount/{id}")]
//         public IActionResult Acount(int id)
//         {
//             ViewBag.id = id;
//             return View();
//         }