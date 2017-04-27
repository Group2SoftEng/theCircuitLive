<?php
error_reporting(E_ALL);
require_once "functions.php";

//
function chat_exists ($user1, $user2) {
    $con = get_connection();
    $sql = "SELECT * FROM user_messages
            WHERE (user_one LIKE $user1 AND user_two LIKE $user2)
            OR (user_one LIKE $user2 AND user_two LIkE $user1)";
    $exists = true;
    $result = mysqli_query($con, $sql);
    if ($result->num_rows == 0) {
        $exists = false;
    }
    mysqli_close($con);
    return $exists;
}

// 
function create_chat ($user1, $user2) {
    $con = get_connection();
    $sql = "INSERT INTO user_messages (user_one, user_two, file_path) VALUES
            ('$user1', '$user2', '../../softeng05_config/chats/" . $user1 . "-" . $user2 . ".txt')";
    mysqli_query($con, $sql) or die("chat creation failed");
    mysqli_close($con);
    $file = fopen("../../softeng05_config/chats/$user1" . "-" . $user2 . ".txt", "w+");
    fclose($file);
}

// send_chat : $username [STRING], $password [STRING] --> success[BOOLEAN]
//
function send_chat($username, $password, $user2, $message) {
   // Validate first user credentials 
   // Validate $user2 existing
   $con = get_connection();
   if (user_login1($con, $username, $password)) {
        $sql = "SELECT user_id FROM users WHERE username LIKE '$username'";
        $result = mysqli_query($con, $sql) or die("no");
        if ($result->num_rows == 0) {
            $success = false;
        }
        else {
            $n = $result->fetch_array(MYSQLI_NUM)[0];
            $path = mysqli_query($con, "SELECT file_path FROM user_messages 
            WHERE (user_one = $n AND user_two = $user2)
            OR (user_one = $user2 AND user_two = $n)");

            $path = $path->fetch_array(MYSQLI_NUM)[0];

            $file = fopen($path, "a");
            fwrite($file, "\n" . "$username: " . $message); 
            fclose($file);
        }
   }
   else {
     echo "invalid credentials";
   }
    mysqli_close($con);
}

// Receive a chat from the text file
function get_chat($username, $password, $user2) {
    $con = get_connection();
    $res = "";
    if (user_login1($con, $username, $password)) {
        $sql = "SELECT user_id FROM users WHERE username LIKE '$username'";
        $result = mysqli_query($con, $sql) or die("Failed to receive chat");
        if ($result->num_rows == 0) {
            $success = false;
        }
        else {
            $n = $result->fetch_array(MYSQLI_NUM)[0];
            $path = mysqli_query($con, "SELECT file_path FROM user_messages 
            WHERE (user_one = $n AND user_two = $user2)
            OR (user_one = $user2 AND user_two = $n)");

            $path = $path->fetch_array(MYSQLI_NUM)[0];

            $res = explode("\n", file_get_contents($path));
            /*$file = fopen($path, "r");
            while (!feof($file)) {
                $res .= fgets($file);
            }
            fclose($file);*/
        }
    }
    else {
        echo "invalid credentials";
    }
    mysqli_close($con);
    return $res;
}

function get_users_chatted($username, $password) {
    $con = get_connection();
    if (user_login1($con, $username, $password)) {
            $id = username_to_id($con, $username);

            $sql = "SELECT * FROM users WHERE user_id in 
            (SELECT user_two FROM user_messages WHERE (user_one = $id))";    
            $users = mysqli_query($con, $sql) or die ("users chat failed");

            $user_set = array();

            while ($result = $users->fetch_assoc()) {
                $user["Id"] = $result["user_id"];
                $user["UserName"] = $result["username"];
                $user["Password"] = "";
                $user["FirstName"] = $result["user_first"];
                $user["LastName"] = $result["user_last"];
                $user["Email"] = $result["user_email"];
                $user["ProfilePicture"] = $result["user_profile_picture"];
                $user["State"] = $result["user_state"];
                $user["PhoneNumber"] = $result["user_phone"];
                $user["Zip"] = $result["user_zip"];
                $user["Address"] = $result["user_address"];
                $user["AboutMe"] = $result["user_about_me"];
                $user["City"] = $result["user_city"];
                array_push($user_set, $user);
        }

    }
    else {
        echo "invalid credentials";
    }
    mysqli_close($con);
    return json_encode($user_set, JSON_NUMERIC_CHECK);
}
?>
