﻿using Microsoft.AspNetCore.Mvc;
        [HttpPost]
        public JsonResult Login(User user)
        {
            UserAccess userAccess = new UserAccess();
            List<User> users = userAccess.GetUserByUsernameAndPassword(user.Username ?? "", user.Password ??"");


            if (users.Count == 0)
            {
                // 用户不存在，返回登录失败的信息
                return new JsonResult(new { success = false, message = "Login failed: User not found" });
            }

            // 用户存在，返回用户信息
            User loggedInUser = users[0];
            return new JsonResult(new { success = true, message = "Login successful", user = loggedInUser });
        }
