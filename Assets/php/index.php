<?php 
	include_once("db.php");

	
	function getUserData($username, $password){
		GLOBAL $con;
		$enc = sha1($password); 
		$sql = "SELECT userData, username FROM user WHERE username=? AND password=?";
		$st = $con->prepare($sql);

		$st->execute(array($username, sha1($password)));
		$all = $st->fetchAll();

		if(count($all) >0){

			echo $all[0]['userData'];
			
			
		}
		else{
			echo "error";
		}

		
		
		
		
		
	}

	function pushUserData($data, $username, $password){
		GLOBAL $con;

		$sql = "UPDATE User SET userData='$data' WHERE username='$username'";
		$st = $con->prepare($sql);

		try{
			$st->execute();
			$all=$st->fetchAll();
			if (count($all) > 0){

				echo $all[0]['userData'];
			}

			exit();
			
		} catch(PDOException $e){
			echo $sql."<br>".$e->getMessage();
		}
		
	}

	function Login($username, $password){
		GLOBAL $con;

		$sql = "SELECT username FROM User WHERE username=? AND password=?";
		$st=$con->prepare($sql);

		$st->execute(array($username, sha1($password)));//encrypt password
		$all=$st->fetchAll();
		if (count($all) == 1){
			echo "SERVER: ID#".$all[0]["username"];
			echo "SERVER: Login successful!";
			
		}
		else{
			//if username or password are empty strings
			
			echo "error - Duplicate users. Contact admin!";
		}

		
	}


	if(isset($_POST["data"]) && !empty($_POST["data"]) && isset($_POST["username"]) && !empty($_POST["username"]) && 
	isset($_POST["password"]) && !empty($_POST["password"])){
		
		pushUserData($_POST["data"], $_POST["username"], $_POST["password"]);
	} else if (isset($_POST["username"]) && !empty($_POST["username"]) && 
		isset($_POST["password"]) && !empty($_POST["password"])){

		getUserData($_POST["username"], $_POST["password"]);
	}
	else{
		echo "error - Empty fields!";
	}

	// getUserData("johndoe", "johndoe");

	

	//if username or password is null (not set)
	// echo "SERVER: Logged in";

	//exit():  means end server connection (don't execute the rest)
?>