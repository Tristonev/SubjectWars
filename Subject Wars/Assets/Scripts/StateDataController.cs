using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * StateDataController is a class that is intended to manage the transition of data between scenes.
 * It holds 4 fields.
 */
public class StateDataController : MonoBehaviour
{
    //Wins and losses are set to -1 to indicate a score has not been set for this user yet
    public static int wins = -1;
    public static int losses = -1;

    //Email holds the logged in user
    public static string email = "";

    //tempEmail holds the email of the user who last attempted to login (whether successful or not)
    public static string tempEmail = "";
}
